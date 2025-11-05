

/*** Mainly referred to https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide ***/

const validSerialCode = 's123'; 



async function login() {
    const loginId = document.getElementById('loginId').value;
    const password = document.getElementById('password').value;
    const serialCode = document.getElementById('serialCode').value;

    
    if (serialCode !== validSerialCode) {
        alert("Invalid Serial Code.");
        return;
    }

    
    if (parseInt(loginId) <= 999) {
        alert("Invalid Admin ID!!");
        return;
    }

    
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

                
                window.location.href = "/Home/AdminDash"; 
            } else {
                alert("Invalid User ID or Password.");
            }
        } else {
            alert("Error fetching user details: " + response.statusText);
        }
    } catch (error) {
        alert("An error occurred during the login process: " + error.message);
    }
}





async function createUser() {
    
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {
        
        alert('Error: No session data found. Please log.');
        return; 
    }

    
    const userData = {
        Id: parseInt(document.getElementById('userId').value),
        name: document.getElementById('name').value,
        email: document.getElementById('email').value,
        address: document.getElementById('address').value,
        phone: document.getElementById('phone').value,
        picture: document.getElementById('picture').value,
        password: document.getElementById('password').value
    };

    try {
        const response = await fetch('http://localhost:5224/api/BankRestAPI/CreateUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(userData)
        });

        if (response.ok) {
            const data = await response.json();
            alert('User created successfully!');
            createAudit(parsedUserData.accountNO, `Created User for user ID: ${userData.Id}`);
            console.log(data); 
        } else {
            const errorData = await response.json();
            alert('Error creating user: ' + errorData.message);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An unexpected error occurred.');
    }


}


async function updateUser() {
    
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {

        alert('Error: No session data found. Please log.');
        return;
    }

   
    const userData = {
        Id: parseInt(document.getElementById('userId').value),
        name: document.getElementById('name').value,
        email: document.getElementById('email').value,
        address: document.getElementById('address').value,
        phone: document.getElementById('phone').value,
        picture: document.getElementById('picture').value,
        password: document.getElementById('password').value
    };

    try {
        const response = await fetch('http://localhost:5224/api/BankRestAPI/UpdateUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(userData)
        });

        if (response.ok) {
            alert('User updated successfully!');
            createAudit(parsedUserData.accountNO, `Updated user for user ID: ${userData.Id}`);
        } else {
            
            const responseText = await response.text(); 
            console.error('Response Text:', responseText); 

            try {
                const errorData = JSON.parse(responseText); 
                alert(`Error updating admin: ${errorData.message || 'Unknown error'}`);
            } catch (parseError) {
               
                alert(`Error updating admin: ${responseText || 'Unknown error'}`);
            }
        }
    } catch (error) {
        console.error('Error:', error);
        alert(`An unexpected error occurred: ${error.message}`);
    }
}

async function updateAdmin() {
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {
        alert('Error: No session data found. Please log in.');
        return;
    }

    const parsedUserData = JSON.parse(sessionUserData); 
    const userData = {
        Id: parsedUserData.accountNO, 
        name: document.getElementById('name').value,
        email: document.getElementById('email').value,
        address: document.getElementById('address').value,
        phone: document.getElementById('phone').value,
        picture: document.getElementById('picture').value,
        password: document.getElementById('password').value
    };

    try {
        const response = await fetch('http://localhost:5224/api/BankRestAPI/UpdateUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(userData) 
        });

        if (response.ok) {
            alert('User updated successfully!');
        } else {
            const responseText = await response.text(); 
            console.error('Response Text:', responseText); 

            try {
                const errorData = JSON.parse(responseText); 
                alert(`Error updating admin: ${errorData.message || 'Unknown error'}`);
            } catch (parseError) {
                alert(`Error updating admin: ${responseText || 'Unknown error'}`);
            }
        }
    } catch (error) {
        console.error('Error:', error);
        alert(`An unexpected error occurred: ${error.message}`);
    }
}


async function deactivateUser() {
   
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {
        
        alert('Error: No session data found. Please log in.');
        return; 
    }

    const userId = document.getElementById('deactivateUserId').value; 

    if (!userId) {
        alert("User ID is required.");
        return;
    }

    try {
        
        const getUserResponse = await fetch(`http://localhost:5224/api/BankRestAPI/GetUser/${userId}`);

        if (getUserResponse.ok) {
            const userData = await getUserResponse.json();

            
            if (userData.name.endsWith('#')) {
                alert("Error: User is already deactivated.");
                return; 
            }

            
            userData.Id = userId;  

            
            userData.name += "#";

            
            const updateUserResponse = await fetch('http://localhost:5224/api/BankRestAPI/UpdateUser', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(userData) 
            });

            if (updateUserResponse.ok) {
                alert("User deactivated successfully!");
                const parsedUserData = JSON.parse(sessionUserData);
                createAudit(parsedUserData.accountNO, `Deactivated User for user ID: ${userId}`);
            } else {
                const errorText = await updateUserResponse.text(); 
                alert('Error deactivating user: ' + errorText); 
                console.error('Error deactivating user:', errorText);
            }
        } else {
            const errorText = await getUserResponse.text(); 
            alert('Error fetching user data: ' + errorText);
            console.error('Error fetching user data:', errorText);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An unexpected error occurred: ' + error.message);
    }
}


async function activateUser() {
    
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {
        
        alert('Error: No session data found. Please log in.');
        return; 
    }

    const userId = document.getElementById('deactivateUserId').value; 

    if (!userId) {
        alert("User ID is required.");
        return;
    }

    try {
        
        const getUserResponse = await fetch(`http://localhost:5224/api/BankRestAPI/GetUser/${userId}`);

        if (getUserResponse.ok) {
            const userData = await getUserResponse.json();

            
            userData.Id = userId;  

            
            if (userData.name.endsWith('#')) {
                userData.name = userData.name.slice(0, -1); 
            }

            
            const updateUserResponse = await fetch('http://localhost:5224/api/BankRestAPI/UpdateUser', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(userData) 
            });

            if (updateUserResponse.ok) {
                alert("User activated successfully!");
                const parsedUserData = JSON.parse(sessionUserData);
                createAudit(parsedUserData.accountNO, `Activated User for user ID: ${userId}`);
            } else {
                const errorText = await updateUserResponse.text(); 
                alert('Error activating user: ' + errorText); 
                console.error('Error activating user:', errorText);
            }
        } else {
            const errorText = await getUserResponse.text(); 
            alert('Error fetching user data: ' + errorText);
            console.error('Error fetching user data:', errorText);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An unexpected error occurred: ' + error.message);
    }
}

async function resetPassword() {
    
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {
        
        alert('Error: No session data found. Please log in or provide session details.');
        return; 
    }

    const userId = document.getElementById('resetUserId').value; 
    const newPassword = document.getElementById('newPassword').value; 

    if (!userId || !newPassword) {
        alert('Error: No session data found. Please log.');
        return;
    }

    try {
        
        const getUserResponse = await fetch(`http://localhost:5224/api/BankRestAPI/GetUser/${userId}`);

        if (getUserResponse.ok) {
            const userData = await getUserResponse.json();

            
            userData.Id = userId;  

            
            userData.password = newPassword; 

            
            const updateUserResponse = await fetch('http://localhost:5224/api/BankRestAPI/UpdateUser', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(userData) 
            });

            if (updateUserResponse.ok) {
                alert("Password reset successfully!");
                const parsedUserData = JSON.parse(sessionUserData);
                createAudit(parsedUserData.accountNO, `Made a password reset for user ID: ${userId}`);
            } else {
                const errorText = await updateUserResponse.text(); 
                alert('Error resetting password: ' + errorText); 
                console.error('Error resetting password:', errorText);
            }
        } else {
            const errorText = await getUserResponse.text(); 
            alert('Error fetching user data: ' + errorText);
            console.error('Error fetching user data:', errorText);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An unexpected error occurred: ' + error.message);
    }
}


document.getElementById('searchButton').addEventListener('click', searchUser);

async function searchUser() {
    
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {
        
        alert('Error: No session data found. Please log.');
        return; 
    }

    const userId = document.getElementById('searchById').value.trim();
    const userName = document.getElementById('searchByName').value.trim();
    const userDetailsDiv = document.getElementById('userDetails');

    
    userDetailsDiv.innerHTML = '';

    try {
        let userData;

        if (userId) {
            
            const response = await fetch(`http://localhost:5224/api/BankRestAPI/GetUser/${userId}`);
            if (!response.ok) {
                throw new Error('User not found with the given ID.');
            }
            userData = await response.json();
            
            userData = [userData];
        } else if (userName) {
            
            const response = await fetch(`http://localhost:5224/api/BankRestAPI/GetUserByName/${userName}`);
            if (!response.ok) {
                throw new Error('User not found with the given name.');
            }
            userData = await response.json();
        } else {
            alert('Please enter either User ID or Name to search.');
            return;
        }

        
        if (Array.isArray(userData) && userData.length > 0) {
            
            const user = userData[0];
            userDetailsDiv.innerHTML = `
                <p><strong>Name:</strong> ${user.name}</p>
                <p><strong>Email:</strong> ${user.email}</p>
                <p><strong>Address:</strong> ${user.address}</p>
                <p><strong>Phone:</strong> ${user.phone}</p>
                <p><strong>Picture:</strong> <img src="/js/${user.picture}" alt="${user.name}" width="100" /></p>
            `;
        } else {
            userDetailsDiv.innerHTML = `<p class="text-danger">No user found.</p>`;
        }
    } catch (error) {
        userDetailsDiv.innerHTML = `<p class="text-danger">${error.message}</p>`;
        console.error('Error:', error);
    }
}


async function searchAccount() {
    
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {
        
        alert('Error: No session data found. Please log.');
        return; 
    }

    const accountNo = document.getElementById('accountNo').value.trim();
    const accountDetailsDiv = document.getElementById('accountDetails');

    
    accountDetailsDiv.innerHTML = '';

    if (!accountNo) {
        alert("Account No is required.");
        return;
    }

    try {
        
        const response = await fetch(`http://localhost:5224/api/BankRestAPI/GetAccount/${accountNo}`);

        if (!response.ok) {
            throw new Error('Account not found with the given number.');
        }

        const accountData = await response.json();

        
        accountDetailsDiv.innerHTML = `
            <p><strong>Name:</strong> ${accountData.name}</p>
            <p><strong>Email:</strong> ${accountData.email}</p>
            <p><strong>Address:</strong> ${accountData.address}</p>
            <p><strong>Phone:</strong> ${accountData.phone}</p>
            <p><strong>Balance:</strong> ${accountData.balance}</p>
        `;
    } catch (error) {
        accountDetailsDiv.innerHTML = `<p class="text-danger">${error.message}</p>`;
        console.error('Error:', error);
    }
}


    

    

async function loadTransactions() {
    const sessionUserData = sessionStorage.getItem('userData');

    if (!sessionUserData) {
        alert('Error: No session data found. Please log in.');
        return;
    }

    const itemCount = document.getElementById('itemCount').value;
    const accountFilter = document.getElementById('accountFilter').value;
    const startDate = document.getElementById('startDate').value;
    const endDate = document.getElementById('endDate').value;
    const url = 'http://localhost:5224/api/BankRestAPI/GetAllTransactions';

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`Error fetching transactions: ${response.statusText}`);
        }

        const transactions = await response.json();
        const transactionTableBody = document.getElementById('transactionTableBody');
        transactionTableBody.innerHTML = ''; 

    
        let filteredTransactions = transactions.filter(transaction => {
            const accountMatch = transaction.accountNO.toString().includes(accountFilter);
            const transactionDate = new Date(transaction.date);

            
            const dateMatch = (!startDate || transactionDate >= new Date(startDate)) &&
                (!endDate || transactionDate <= new Date(endDate));

            return accountMatch && dateMatch;
        });

        // Limit the number of transactions displayed
        const limit = itemCount === 'all' ? filteredTransactions.length : parseInt(itemCount);
        const transactionsToDisplay = filteredTransactions.slice(0, limit);

    
        transactionsToDisplay.forEach(transaction => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${transaction.transactionID}</td>
                <td>${transaction.accountNO}</td>
                <td>$${parseFloat(transaction.amount).toFixed(2)}</td>
                <td>${transaction.description}</td>
                <td>${new Date(transaction.date).toLocaleString()}</td>
            `;
            transactionTableBody.appendChild(row);
        });
    } catch (error) {
        console.error('Error loading transactions:', error);
        alert('An error occurred while loading transactions: ' + error.message);
    }
}

async function logout() {
    
    sessionStorage.clear();

   
    alert("You have been logged out.");

    
    window.location.href = "/Home/Index";
}

async function createAudit(accountNO, description) {
    
    const auditId = 'A' + Math.floor(1000 + Math.random() * 9000);

   
    const currentDateTime = new Date().toLocaleString();  

    
    const auditRecord = `Admin ${accountNO}: ${description}. Action performed on ${currentDateTime}`;

    const auditData = {
        auditId: auditId,
        auditRecord: auditRecord
    };

    try {
        
        const response = await fetch('http://localhost:5224/api/BankRestAPI/CreateAudit', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(auditData)
        });

        if (response.ok) {
            console.log('Audit created successfully!');
        } else {
            const errorData = await response.json();
            console.error('Error creating audit: ', errorData.message);
        }
    } catch (error) {
        console.error('Error creating audit:', error);
    }
}

async function loadAudits() {
    try {
        const response = await fetch('http://localhost:5224/api/BankRestAPI/GetAudits');
        if (response.ok) {
            const audits = await response.json();

            
            const tbody = document.getElementById('auditTableBody');
            tbody.innerHTML = ''; 

           
            audits.forEach(audit => {
                const row = document.createElement('tr');
                row.id = `auditRow-${audit.auditId}`; 

                
                const auditIdCell = document.createElement('td');
                auditIdCell.id = `auditIdCell-${audit.auditId}`; 
                auditIdCell.textContent = audit.auditId;
                row.appendChild(auditIdCell);

                
                const auditRecordCell = document.createElement('td');
                auditRecordCell.id = `auditRecordCell-${audit.auditId}`; 
                auditRecordCell.textContent = audit.auditRecord;
                row.appendChild(auditRecordCell);

                
                tbody.appendChild(row);
            });
        } else {
            alert('Failed to load audits');
        }
    } catch (error) {
        console.error('Error fetching audits:', error);
        alert('An error occurred while loading audits');
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
        profilePicture.src = `/js/${userData.picture}`; 
        //profilePicture.src = './Home/man.png';


        //await fetchAccountDetails(userData.accountNO);
    }
}







// Attach event listener to the create user button
