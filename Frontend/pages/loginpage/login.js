document.getElementById('loginForm').addEventListener('submit', async (event) => {
    event.preventDefault();

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const feedback = document.getElementById('feedback');

    try {
        const response = await fetch('https://localhost:7052/api/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, password }),
        });        

        if (response.ok) {
            const data = await response.json();
            feedback.textContent = 'Login bem-sucedido!';
            feedback.style.color = 'green';

            // Salvar token ou redirecionar
            localStorage.setItem('token', data.token);
            window.location.href = './patients/index.html'; // Substitua pela página principal
        } else {
            const error = await response.json();
            feedback.textContent = error.message || 'Erro ao fazer login.';
            feedback.style.color = 'red';
        }
    } catch (err) {
        feedback.textContent = 'Erro de conexão. Tente novamente.';
        feedback.style.color = 'red';
    }
});