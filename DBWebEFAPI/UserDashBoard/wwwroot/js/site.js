const apiBaseUrl = 'http://localhost:5224/api/BankRestAPI';

async function fetchUserData(userId) {
    const response = await fetch(`${apiBaseUrl}/GetUser/${userId}`);
    if (!response.ok) {
        throw new Error('Failed to fetch user data');
    }
    return await response.json();
}

async function fetchAccountData(accountNo) {
    const response = await fetch(`${apiBaseUrl}/GetAccount/${accountNo}`);
    if (!response.ok) {
        throw new Error('Failed to fetch account data');
    }
    return await response.json();
}

function updateDashboard(userData, accountData) {
    const dashboard = document.getElementById('user-dashboard');
    dashboard.innerHTML = `
        <h2>Welcome, ${userData.Name}</h2>
        <div class="user-profile">
            <img src="${userData.Picture}" alt="Profile Picture">
            <p>Email: ${userData.Email}</p>
            <p>Phone: ${userData.Phone}</p>
            <p>Address: ${userData.Address}</p>
        </div>
        <div class="account-summary">
            <h3>Account Summary</h3>
            <p>Account Number: ${accountData.AccountNO}</p>
            <p>Balance: $${accountData.Balance}</p>
        </div>
        <div class="transaction-history">
            <h3>Transaction History</h3>
            <!-- Add transaction history table here -->
        </div>
        <div class="money-transfer">
            <h3>Money Transfer</h3>
            <form id="transferForm">
                <input type="text" id="recipientAccount" placeholder="Recipient Account Number" required>
                <input type="number" id="amount" placeholder="Amount" required>
                <input type="text" id="description" placeholder="Description">
                <button type="submit">Transfer</button>
            </form>
        </div>
    `;

    // Add event listener for money transfer form
    document.getElementById('transferForm').addEventListener('submit', handleMoneyTransfer);
}

async function handleMoneyTransfer(event) {
    event.preventDefault();
    // Implement money transfer logic here
    // You'll need to create a new endpoint in your API for this
}

// Initialize dashboard
async function initDashboard() {
    try {
        const userId = 1; // This should be dynamically set based on the logged-in user
        const userData = await fetchUserData(userId);
        const accountData = await fetchAccountData(userData.AccountNO);
        updateDashboard(userData, accountData);
    } catch (error) {
        console.error('Error initializing dashboard:', error);
    }
}

// Call initDashboard when the page loads
if (document.getElementById('user-dashboard')) {
    document.addEventListener('DOMContentLoaded', initDashboard);
}