using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Data;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AndreiaFerreira.ClinicaApi.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ClinicDbContext _context;
        private readonly IClientRepository _clientRepository;

        public SessionRepository(ClinicDbContext context, IClientRepository clientRepository)
        {
            _context = context;
            _clientRepository = clientRepository;
        }


        public async Task<SessionModel> CreateSessionAsync(SessionModel session)
        {
            var client = await _clientRepository.GetClientAsync(session.Paciente.CPF);
            if (client == null)
            {
                throw new PersonalizedException("Cliente não encontrado", HttpStatusCode.NotFound);
            }

            try
            {
                _context.Sessoes.Add(session);
                await _context.SaveChangesAsync();
                return session;
            }
            catch (Exception ex)
            {
                throw new PersonalizedException("Ocorreu um erro ao tentar criar uma sessão", HttpStatusCode.InternalServerError);
            }
        }

        public async Task DeleteSessionAsync(int id)
        {
            try
            {
                var session = await _context.Sessoes.FindAsync(id);
                if (session == null)
                {
                    throw new PersonalizedException("Sessão não encontrada", HttpStatusCode.NotFound);
                }

                _context.Sessoes.Remove(session);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersonalizedException("Ocorreu um erro ao tentar deletar uma sessão", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<List<SessionModel>> GetAllSessionsAsync()
        {
            try
            {
                return await _context.Sessoes.Include(x => x.Paciente).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new PersonalizedException("Ocorreu um erro ao tentar buscar todas as sessões", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<SessionModel> GetSessionAsync(int id)
        {
            try
            {
                var session = await _context.Sessoes.Include(x => x.Paciente).FirstOrDefaultAsync(x => x.Id == id);
                if (session == null)
                {
                    throw new PersonalizedException("Sessão não encontrada", HttpStatusCode.NotFound);
                }

                return session;
            }
            catch (PersonalizedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalizedException("Ocorreu um erro ao tentar buscar uma sessão", HttpStatusCode.InternalServerError);
            }
        }
        public async Task<List<SessionModel>> GetSessionsByClientAsync(string cpf)
        {
            try
            {
                var client = await _clientRepository.GetClientAsync(cpf);
                if (client == null)
                {
                    throw new PersonalizedException("Cliente não encontrado", HttpStatusCode.NotFound);
                }

                var sessions = await _context.Sessoes.Include(s => s.Paciente)
                    .Where(s => s.Paciente.Id == client.Id)
                    .ToListAsync();
                if (sessions == null)
                {
                    throw new PersonalizedException("Sessão não encontrada", HttpStatusCode.NotFound);
                }

                return sessions;
            }
            catch (KeyNotFoundException ex)
            {
                throw new PersonalizedException("Cliente não encontrado", HttpStatusCode.NotFound);
            }
            catch (PersonalizedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new PersonalizedException("Ocorreu um erro ao tentar buscar uma sessão", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<List<SessionModel>> GetSessionsByDateAsync(DateTime? initialDate = null, DateTime? finalDate = null)
        {
            var today = DateTime.Today;

            var query = _context.Sessoes.AsQueryable();

            if (initialDate.HasValue)
            {
                query = query.Where(s => s.DataHoraSessao.Date >= initialDate.Value.Date);
            }

            if (finalDate.HasValue)
            {
                query = query.Where(s => s.DataHoraSessao.Date <= finalDate.Value.Date);
            }

            try
            {
                return await query.Include(x => x.Paciente).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new PersonalizedException("Ocorreu um erro ao tentar buscar as sessões por data", HttpStatusCode.InternalServerError);
            }
        }


        public async Task<SessionModel> UpdateSessionAsync(UpdateSessionDTO updateSessionDTO)
        {
            try
            {
                var sessionFromDb = await _context.Sessoes.FindAsync(updateSessionDTO.Id);
                if (sessionFromDb == null)
                {
                    throw new PersonalizedException("Sessão não encontrada", HttpStatusCode.NotFound);
                }

                ClientModel client = null;
                if (updateSessionDTO.Cpf != null)
                {
                    client = await _clientRepository.GetClientAsync(updateSessionDTO.Cpf);
                    if (client == null)
                    {
                        throw new PersonalizedException("Cliente não encontrado", HttpStatusCode.NotFound);
                    }
                }

                sessionFromDb.DataHoraSessao = updateSessionDTO.DataHoraSessao ?? sessionFromDb.DataHoraSessao;
                sessionFromDb.Observacoes = updateSessionDTO.Observacoes ?? sessionFromDb.Observacoes;
                sessionFromDb.Profissional = updateSessionDTO.Profissional ?? sessionFromDb.Profissional;
                sessionFromDb.TipoDeServico = updateSessionDTO.TipoDeServico ?? sessionFromDb.TipoDeServico;
                sessionFromDb.Paciente = client ?? sessionFromDb.Paciente;

                _context.Sessoes.Update(sessionFromDb);
                await _context.SaveChangesAsync();
                return sessionFromDb;
            }
            catch (PersonalizedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalizedException("Ocorreu um erro ao tentar atualizar uma sessão", HttpStatusCode.InternalServerError);
            }
        }
    }
}

