document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const email = document.getElementById("login").value;
    const password = document.getElementById("password").value;

    fetch("api/auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email, password })
    })
    .then(res => res.json())
    .then(data => {
        if (data.success) {
            
            const formattedData = JSON.stringify(data.data, null, 2);
            showMessage("Connexion réussie !<br><br><pre>" + formattedData + "</pre>", true);
        } else {
            showMessage("Erreur : " + (data.data?.ResultMessage ?? "Impossible de se connecter"), false);
        }
    })
    .catch(err => console.log( err));
});

function showMessage(message, success = true) {
    const container = document.getElementById("message");
    container.innerHTML = `<div class="${success ? "success" : "error"}">${message}</div>`;
}