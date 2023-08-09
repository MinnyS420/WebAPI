document.addEventListener("DOMContentLoaded", () => {
    const getAllButton = document.getElementById("getAllButton");
    const getAllResult = document.getElementById("getAllResult");

    const getUserButton = document.getElementById("getUserButton");
    const userNameInput = document.getElementById("userNameInput");
    const getUserResult = document.getElementById("getUserResult");

    const apiUrl = "/api/users";

    getAllButton.addEventListener("click", async () => {
        const response = await fetch(apiUrl);
        const data = await response.json();
        getAllResult.innerHTML = data.join("<br>");
    });

    getUserButton.addEventListener("click", async () => {
        const userName = userNameInput.value;
        if (!userName) {
            getUserResult.innerHTML = "Please enter a username.";
            return;
        }

        const response = await fetch(`${apiUrl}/${encodeURIComponent(userName)}`);
        if (response.status === 404) {
            getUserResult.innerHTML = "User not found.";
            return;
        }

        const data = await response.text();
        getUserResult.innerHTML = data;
    });
});
