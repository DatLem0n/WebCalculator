document.getElementById("triggerButton").addEventListener("click", async function() {
    try {
        const response = await fetch("http://localhost:8080/backendEndpoint");
        const data = await response.text();
        document.getElementById("responseText").innerText = data;
    } catch (error) {
        console.error("Error fetching data:", error);
    }
});