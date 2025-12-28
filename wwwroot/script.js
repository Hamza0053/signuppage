document.getElementById("signupForm").addEventListener("submit", async e => {
    e.preventDefault();

    const data = {
        fullName: document.getElementById("fullName").value,
        email: document.getElementById("email").value,
        password: document.getElementById("password").value
    };

    const response = await fetch("/api/auth/signup", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    const message = await response.text();
    alert(message);
});
