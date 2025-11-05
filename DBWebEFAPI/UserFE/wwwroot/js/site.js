// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


/*** Mainly referred to https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide ***/

console.log("site.js loaded");
async function login() {
    const loginId = document.getElementById('loginId').value;
    const password = document.getElementById('password').value;

   
    const url = `http://localhost:5224/api/BankRestAPI/GetUser/${loginId}`;

    try {
        
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        
        if (response.ok) {
            const userData = await response.json();

            
            if (userData.name.endsWith('#')) {
                alert("Account deactivated.");
                return; 
            }

            
            if (userData.password === password) {
                alert("Login successful!");

                
                sessionStorage.setItem('userData', JSON.stringify({
                    name: userData.name,
                    email: userData.email,
                    phone: userData.phone,
                    address: userData.address, 
                    picture: userData.picture, 
                    accountNO: loginId 
                }));

                
                window.location.href = "/Home/Dashboard"; 
            } else {
                alert("Invalid login ID or password.");
            }
        } else {
            alert("Error fetching user details: " + response.statusText);
        }
    } catch (error) {
        alert("An error occurred during the login process: " + error.message);
    }
}




async function loadUserDetails() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if (userData) {
       
        document.getElementById('userName').innerText = userData.name;
        document.getElementById('userEmail').innerText = userData.email;
        document.getElementById('userPhone').innerText = userData.phone;
        document.getElementById('userAddress').innerText = userData.address; 

        
        const profilePicture = document.getElementById('profilePicture');
         profilePicture.src = `/js/${userData.picture}` ; 
        //profilePicture.src = './Home/man.png';

       
        await fetchAccountDetails(userData.accountNO);
    }
}

async function fetchAccountDetails(accountNo) {
    const url = `http://localhost:5224/api/BankRestAPI/GetAccount/${accountNo}`;

    try {
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (response.ok) {
            const accountData = await response.json();

            
            document.getElementById('accountNumber').innerText = accountNo; 
            document.getElementById('currentBalance').innerText = `$${parseFloat(accountData.balance).toFixed(2)}`; // Display the balance
        } else {
            const errorMessage = await response.text();
            console.error("Error fetching account details: " + errorMessage);
            
        }
    } catch (error) {
        
        alert("An error occurred while fetching account details: " + error.message);
    }
}

async function updateAccount() {
    
    const updatedEmail = document.getElementById('updateEmail').value;
    const updatedPhone = document.getElementById('updatePhone').value;
    const updatedPassword = document.getElementById('updatePassword').value;

    
    const userData = JSON.parse(sessionStorage.getItem('userData'));

    
    const accountNO = userData.accountNO;

    
    if (!accountNO) {
        alert("Account number not found.");
        return;
    }

    
    const accountData = {
        Id: accountNO,
        name: userData.name,        
        email: updatedEmail,
        phone: updatedPhone,
        picture: userData.picture,
        password: updatedPassword,
        address: userData.address
        
    };

    try {
        
        const response = await fetch('http://localhost:5224/api/BankRestAPI/UpdateUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(accountData)
        });

        if (response.ok) {
            alert("Profile updated successfully!");
            
        } else {
            const errorMessage = await response.text();
            alert("Error updating profile: " + errorMessage);
        }
    } catch (error) {
        
        alert("An error occurred during the update process: " + error.message);
    }
}

async function deposit() {
    const amount = parseFloat(document.getElementById('depositAmount').value);
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    const accountNO = userData.accountNO;

    if (!amount || amount <= 0) {
        alert("Please enter a valid deposit amount.");
        return;
    }

    const depositData = {
        AccountNo: accountNO,
        Amount: amount,
        Type: "Deposit"
    };

    try {
        const response = await fetch('http://localhost:5224/api/BankRestAPI/Deposit', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(depositData)
        });

        if (response.ok) {
            alert("Deposit successful!");
            
            await fetchAccountDetails(userData.email);
        } else {
            const errorMessage = await response.text();
            alert("Error during deposit: " + errorMessage);
        }
        await fetchAccountDetails(userData.accountNO);
    } catch (error) {
        
        alert("An error occurred during the deposit process: " + error.message);
    }
}

async function withdraw() {
    const amount = parseFloat(document.getElementById('withdrawAmount').value);
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    const accountNO = userData.accountNO;

    if (!amount || amount <= 0) {
        alert("Please enter a valid withdrawal amount.");
        return;
    }

    const withdrawData = {
        AccountNO: accountNO,
        Amount: amount,
        Type: "Withdrawal"
    };

    try {
        const response = await fetch('http://localhost:5224/api/BankRestAPI/Withdrawal', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(withdrawData)
        });

        if (response.ok) {
            alert("Withdrawal successful!");
           
            await fetchAccountDetails(userData.email);
        } else {
            const errorMessage = await response.text();
            alert("Error during withdrawal: " + errorMessage);
        }
        await fetchAccountDetails(userData.accountNO);
    } catch (error) {
        
        alert("An error occurred during the withdrawal process: " + error.message);
    }
}

async function showTransactions() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if (!userData) {
        alert("User data not found. Please log in.");
        return;
    }

    const accountNO = userData.accountNO;
    const url = 'http://localhost:5224/api/BankRestAPI/GetAllTransactions';

    
    const startDateValue = document.getElementById('startDate').value;
    const endDateValue = document.getElementById('endDate').value;

    
    const startDate = startDateValue ? new Date(startDateValue) : null;
    const endDate = endDateValue ? new Date(endDateValue) : null;

    try {
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (response.ok) {
            const transactions = await response.json();
            console.log(transactions); 
            const filteredTransactions = transactions.filter(transaction => {
                const transactionDate = new Date(transaction.date);

                
                if (transaction.accountNO !== Number(accountNO)) return false;

                
                if (startDate && transactionDate < startDate) return false;
                if (endDate && transactionDate > endDate) return false;

                return true;
            });

            const transactionTableBody = document.getElementById('transactionTableBody');
            transactionTableBody.innerHTML = ''; 
           
            if (filteredTransactions.length === 0) {
                transactionTableBody.innerHTML = '<tr><td colspan="5" class="text-center">No transactions found for this account.</td></tr>';
                return;
            }

            filteredTransactions.forEach(transaction => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${transaction.transactionID}</td>
                    <td>${transaction.amount}</td>
                    <td>${transaction.description}</td>
                    <td>${new Date(transaction.date).toLocaleString()}</td>
                `;
                transactionTableBody.appendChild(row);
            });
        } else {
            alert("Error fetching transactions: " + response.statusText);
        }
    } catch (error) {
        
        alert("An error occurred while fetching transactions: " + error.message);
    }
}

async function transfer() {
    const transferAmount = parseFloat(document.getElementById('transferAmount').value);
    const recipientAccountNo = document.getElementById('transferAccount').value;
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    const senderAccountNo = userData.accountNO;

    if (!transferAmount || transferAmount <= 0) {
        alert("Please enter a valid transfer amount.");
        return;
    }

    if (!recipientAccountNo) {
        alert("Please enter a valid recipient account number.");
        return;
    }

    
    const depositData = {
        AccountNo: recipientAccountNo,
        Amount: transferAmount,
        Type: "Transfer"
    };

    try {
        
        const depositResponse = await fetch('http://localhost:5224/api/BankRestAPI/Deposit', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(depositData)
        });

        if (!depositResponse.ok) {
            const depositError = await depositResponse.text();
            alert("Error during Transfer: " + depositError);
            return;
        }
        alert("Transfer to recipient successful!");

        
        const withdrawData = {
            AccountNO: senderAccountNo,
            Amount: transferAmount,
            Type: "Transfer"
        };

        const withdrawResponse = await fetch('http://localhost:5224/api/BankRestAPI/Withdrawal', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(withdrawData)
        });

        if (!withdrawResponse.ok) {
            const withdrawError = await withdrawResponse.text();
            alert("Error during Transfer: " + withdrawError);
            return;
        }

        
        
        await fetchAccountDetails(userData.accountNO);

    } catch (error) {
        
        alert("An error occurred during the transfer process: " + error.message);
    }
}

async function logout() {
    
    sessionStorage.clear();

    
    alert("You have been logged out.");

    
    window.location.href = "/Home/Login";
}






window.onload = loadUserDetails;