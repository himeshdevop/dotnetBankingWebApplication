using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankRestAPI : ControllerBase
    {
        private readonly RestClient _client;

        public BankRestAPI()
        {
            _client = new RestClient("http://localhost:5271");
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userData)
        {
            if (userData == null)
            {
                return BadRequest("User data is required.");
            }

            
            if (userData.Id < 1 || userData.Id > 100)
            {
                return BadRequest("User ID must be between 1 and 100.");
            }

            
            var request = new RestRequest("/Users/Create", Method.Post);

            
            request.AddParameter("name", userData.name, ParameterType.GetOrPost);
            request.AddParameter("email", userData.email, ParameterType.GetOrPost);
            request.AddParameter("address", userData.address, ParameterType.GetOrPost);
            request.AddParameter("phone", userData.phone, ParameterType.GetOrPost);
            request.AddParameter("password", userData.password, ParameterType.GetOrPost);
            request.AddParameter("picture", userData.picture, ParameterType.GetOrPost); 

            
            var response = await _client.ExecuteAsync(request);

            
            if (response.IsSuccessful)
            {
                return Ok((int)response.StatusCode); 
            }

            return StatusCode((int)response.StatusCode); 
        }

        
        [HttpGet("GetUser/{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var request = new RestRequest($"/Users/Details/{userId}", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
               
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response.Content);

                
                var userData = new
                {
                    Name = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'name')]/following-sibling::dd").InnerText.Trim(),
                    Email = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'email')]/following-sibling::dd").InnerText.Trim(),
                    Address = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'address')]/following-sibling::dd").InnerText.Trim(),
                    Phone = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'phone')]/following-sibling::dd").InnerText.Trim(),
                    Picture = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'picture')]/following-sibling::dd").InnerText.Trim(),
                    Password = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'password')]/following-sibling::dd").InnerText.Trim()
                };

                
                return Ok(userData);
            }
            else
            {
                
                return StatusCode((int)response.StatusCode, new { message = "Error fetching user details", details = response.Content });
            }
        }

        
        [HttpGet("GetUserByName/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var usersFound = new List<object>();
            int userId = 1; 
            int maxUserId = 100; 

            while (userId <= maxUserId)
            {
                var request = new RestRequest($"/Users/Details/{userId}", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(response.Content);

                    
                    var userData = new
                    {
                        Name = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'name')]/following-sibling::dd").InnerText.Trim(),
                        Email = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'email')]/following-sibling::dd").InnerText.Trim(),
                        Address = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'address')]/following-sibling::dd").InnerText.Trim(),
                        Phone = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'phone')]/following-sibling::dd").InnerText.Trim(),
                        Picture = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'picture')]/following-sibling::dd").InnerText.Trim(),
                        Password = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'password')]/following-sibling::dd").InnerText.Trim()
                    };

                    
                    if (userData.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        usersFound.Add(userData);
                    }
                }

                userId++; 
            }

            if (usersFound.Count > 0)
            {
                
                return Ok(usersFound);
            }
            else
            {
                return NotFound(new { message = "No users found with the given name." });
            }
        }

        
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel userData)
        {
            if (userData == null || userData.Id <= 0)
            {
                return BadRequest("User data with valid Id is required.");
            }

            
            var request = new RestRequest($"/Users/Edit/{userData.Id}", Method.Post);
            request.AddParameter("Id", userData.Id);
            request.AddParameter("name", userData.name);
            request.AddParameter("email", userData.email);
            request.AddParameter("address", userData.address);
            request.AddParameter("phone", userData.phone);
            request.AddParameter("password", userData.password);
            request.AddParameter("picture", userData.picture);

            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return Ok((int)response.StatusCode);
            }
            return StatusCode((int)response.StatusCode);
        }

        
        [HttpPost("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            
            if (!int.TryParse(userId, out int id))
            {
                return BadRequest("Invalid user ID format.");
            }

            
            var request = new RestRequest($"/Users/Delete", Method.Post);
            request.AddParameter("id", id);

            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.Content);
        }


        /********************************************************/
        
        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountModel accountData)
        {
            if (accountData == null)
            {
                return BadRequest("Account data is required.");
            }

            var request = new RestRequest("/Accounts/Create", Method.Post);
            request.AddParameter("name", accountData.Name);
            request.AddParameter("email", accountData.Email);
            request.AddParameter("address", accountData.Address);
            request.AddParameter("phone", accountData.Phone);
            request.AddParameter("accountNO", accountData.AccountNO);
            request.AddParameter("balance", accountData.Balance);

            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.Content);
        }

        
        [HttpGet("GetAccount/{accountNO}")]
        public async Task<IActionResult> GetAccount(int accountNO)
        {
            var request = new RestRequest($"/Accounts/Details/{accountNO}", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response.Content);

                
                var accountData = new
                {
                    Name = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'name')]/following-sibling::dd").InnerText.Trim(),
                    Email = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'email')]/following-sibling::dd").InnerText.Trim(),
                    Address = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'address')]/following-sibling::dd").InnerText.Trim(),
                    Phone = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'phone')]/following-sibling::dd").InnerText.Trim(),
                    Balance = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'balance')]/following-sibling::dd").InnerText.Trim(),
                };

                return Ok(accountData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { message = "Error fetching account details", details = response.Content });
            }
        }

        
        [HttpPost("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountModel accountData)
        {
            if (accountData == null || accountData.AccountNO <= 0)
            {
                return BadRequest("Valid account data is required.");
            }

            var request = new RestRequest($"/Accounts/Edit/{accountData.AccountNO}", Method.Post);
            request.AddParameter("name", accountData.Name);
            request.AddParameter("email", accountData.Email);
            request.AddParameter("address", accountData.Address);
            request.AddParameter("phone", accountData.Phone);
            request.AddParameter("accountNO", accountData.AccountNO);
            request.AddParameter("balance", accountData.Balance);


            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.Content);
        }

        
        [HttpPost("DeleteAccount/{accountNO}")]
        public async Task<IActionResult> DeleteAccount(int accountNO)
        {
            var request = new RestRequest($"/Accounts/Delete", Method.Post);
            request.AddParameter("id", accountNO);

            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return Ok(response.Content);
            }
            return StatusCode((int)response.StatusCode, response.Content);
        }

        /*********************************/
        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var request = new RestRequest("/Transactions", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response.Content);

                
                var transactionNodes = htmlDoc.DocumentNode.SelectNodes("//tbody/tr");
                var transactionsList = new List<object>();

                if (transactionNodes != null)
                {
                    foreach (var transactionNode in transactionNodes)
                    {
                        
                        var accountNoNode = transactionNode.SelectSingleNode(".//td[1]");
                        var amountNode = transactionNode.SelectSingleNode(".//td[2]");
                        var descriptionNode = transactionNode.SelectSingleNode(".//td[3]");
                        var dateNode = transactionNode.SelectSingleNode(".//td[4]");
                        var transactionIdNode = transactionNode.SelectSingleNode(".//td[5]/a[1]");

                        
                        var transactionData = new
                        {
                            TransactionID = transactionIdNode?.Attributes["href"]?.Value.Split('/').Last() ?? "N/A",
                            AccountNO = int.TryParse(accountNoNode?.InnerText?.Trim(), out int accountNo) ? accountNo : 0,
                            Amount = decimal.TryParse(amountNode?.InnerText?.Trim(), out decimal amount) ? amount : 0m,
                            Description = descriptionNode?.InnerText?.Trim() ?? "N/A",
                            Date = DateTime.TryParse(dateNode?.InnerText?.Trim(), out DateTime date) ? date : DateTime.MinValue
                        };

                        transactionsList.Add(transactionData);
                    }
                }
                else
                {
                    
                    return NotFound(new { message = "No transactions found." });
                }

                
                return Ok(transactionsList);
            }
            else
            {
                
                return StatusCode((int)response.StatusCode, new { message = "Error fetching transactions", details = response.Content });
            }
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositModel depositData)
        {
            if (depositData == null)
            {
                return BadRequest("Deposit data is required.");
            }

            
            if (depositData.Amount <= 0)
            {
                return BadRequest("Deposit amount must be greater than zero.");
            }

            
            var random = new Random();
            var transactionId = "T" + random.Next(1000, 10000).ToString(); 

            
            var request = new RestRequest("/Transactions/Create", Method.Post);
            request.AddParameter("accountNO", depositData.AccountNO, ParameterType.GetOrPost);
            request.AddParameter("transactionId", transactionId, ParameterType.GetOrPost); 
            request.AddParameter("amount", depositData.Amount, ParameterType.GetOrPost);
            request.AddParameter("description", depositData.Type, ParameterType.GetOrPost); 
            request.AddParameter("date", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"), ParameterType.GetOrPost); 

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                return StatusCode((int)response.StatusCode, new { message = "Error processing deposit", details = response.Content });
            }

            
            var accountRequest = new RestRequest($"/Accounts/Details/{depositData.AccountNO}", Method.Get);
            var accountResponse = await _client.ExecuteAsync(accountRequest);

            if (accountResponse.IsSuccessful)
            {
                
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(accountResponse.Content);

                
                var accountData = new AccountModel
                {
                    Name = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'name')]/following-sibling::dd").InnerText.Trim(),
                    Email = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'email')]/following-sibling::dd").InnerText.Trim(),
                    Address = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'address')]/following-sibling::dd").InnerText.Trim(),
                    Phone = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'phone')]/following-sibling::dd").InnerText.Trim(),
                    AccountNO = int.Parse(depositData.AccountNO), 
                    Balance = decimal.Parse(htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'balance')]/following-sibling::dd").InnerText.Trim()).ToString("F2") 
                };

                
                if (accountData == null || accountData.AccountNO <= 0)
                {
                    return BadRequest("Valid account data is required.");
                }

                
                var currentBalance = decimal.Parse(accountData.Balance);
                currentBalance += depositData.Amount;
                accountData.Balance = currentBalance.ToString("F2"); 

                
                var editRequest = new RestRequest($"/Accounts/Edit/{accountData.AccountNO}", Method.Post);
                editRequest.AddParameter("name", accountData.Name);
                editRequest.AddParameter("email", accountData.Email);
                editRequest.AddParameter("address", accountData.Address);
                editRequest.AddParameter("phone", accountData.Phone);
                editRequest.AddParameter("accountNO", accountData.AccountNO);
                editRequest.AddParameter("balance", accountData.Balance);

                var editResponse = await _client.ExecuteAsync(editRequest);
                if (editResponse.IsSuccessful)
                {
                    return Ok(editResponse.Content);
                }

                return StatusCode((int)editResponse.StatusCode, editResponse.Content);
            }
            else
            {
                return StatusCode((int)accountResponse.StatusCode, new { message = "Error fetching account details", details = accountResponse.Content });
            }
        }

        [HttpPost("Withdrawal")]
        public async Task<IActionResult> Withdrawal([FromBody] WithdrawalModel withdrawalData)
        {
            if (withdrawalData == null)
            {
                return BadRequest("Withdrawal data is required.");
            }

            
            if (withdrawalData.Amount <= 0)
            {
                return BadRequest("Withdrawal amount must be greater than zero.");
            }

            
            var accountRequest = new RestRequest($"/Accounts/Details/{withdrawalData.AccountNO}", Method.Get);
            var accountResponse = await _client.ExecuteAsync(accountRequest);

            if (!accountResponse.IsSuccessful)
            {
                return StatusCode((int)accountResponse.StatusCode, new { message = "Error fetching account details", details = accountResponse.Content });
            }

            
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(accountResponse.Content);

            
            var accountData = new AccountModel
            {
                Name = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'name')]/following-sibling::dd").InnerText.Trim(),
                Email = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'email')]/following-sibling::dd").InnerText.Trim(),
                Address = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'address')]/following-sibling::dd").InnerText.Trim(),
                Phone = htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'phone')]/following-sibling::dd").InnerText.Trim(),
                AccountNO = int.Parse(withdrawalData.AccountNO.ToString()), 
                Balance = decimal.Parse(htmlDoc.DocumentNode.SelectSingleNode("//dt[contains(text(), 'balance')]/following-sibling::dd").InnerText.Trim()).ToString("F2") // Ensure Balance is formatted
            };

            
            if (accountData == null || accountData.AccountNO <= 0)
            {
                return BadRequest("Valid account data is required.");
            }

            
            var currentBalance = decimal.Parse(accountData.Balance);
            if (withdrawalData.Amount > currentBalance)
            {
                return BadRequest("Insufficient funds for this withdrawal.");
            }

            
            currentBalance -= withdrawalData.Amount;
            accountData.Balance = currentBalance.ToString("F2"); 

            
            var random = new Random();
            var transactionId = "W" + random.Next(1000, 10000).ToString(); 

            
            var transactionRequest = new RestRequest("/Transactions/Create", Method.Post);
            transactionRequest.AddParameter("accountNO", withdrawalData.AccountNO, ParameterType.GetOrPost);
            transactionRequest.AddParameter("transactionId", transactionId, ParameterType.GetOrPost); 
            transactionRequest.AddParameter("amount", withdrawalData.Amount, ParameterType.GetOrPost);
            transactionRequest.AddParameter("description", withdrawalData.Type, ParameterType.GetOrPost); 
            transactionRequest.AddParameter("date", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"), ParameterType.GetOrPost); 

            var transactionResponse = await _client.ExecuteAsync(transactionRequest);

            if (!transactionResponse.IsSuccessful)
            {
                return StatusCode((int)transactionResponse.StatusCode, new { message = "Error processing withdrawal transaction", details = transactionResponse.Content });
            }

            
            var editRequest = new RestRequest($"/Accounts/Edit/{accountData.AccountNO}", Method.Post);
            editRequest.AddParameter("name", accountData.Name);
            editRequest.AddParameter("email", accountData.Email);
            editRequest.AddParameter("address", accountData.Address);
            editRequest.AddParameter("phone", accountData.Phone);
            editRequest.AddParameter("accountNO", accountData.AccountNO);
            editRequest.AddParameter("balance", accountData.Balance);

            var editResponse = await _client.ExecuteAsync(editRequest);
            if (editResponse.IsSuccessful)
            {
                return Ok(editResponse.Content);
            }

            return StatusCode((int)editResponse.StatusCode, editResponse.Content);
        }

        [HttpPost("CreateAudit")]
        public async Task<IActionResult> CreateAudit([FromBody] Audit auditData)
        {
            if (auditData == null)
            {
                return BadRequest("Audit data is required.");
            }

            
            var request = new RestRequest("/Audits/Create", Method.Post);

            
            request.AddParameter("auditId", auditData.auditId, ParameterType.GetOrPost);
            request.AddParameter("auditRecord", auditData.auditRecord, ParameterType.GetOrPost);

            
            var response = await _client.ExecuteAsync(request);

            
            if (response.IsSuccessful)
            {
                return Ok((int)response.StatusCode); 
            }

            return StatusCode((int)response.StatusCode, response.Content); 
        }

        [HttpGet("GetAudits")]
        public async Task<IActionResult> GetAudits()
        {
            
            var request = new RestRequest("/Audits", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response.Content);

                
                var auditNodes = htmlDoc.DocumentNode.SelectNodes("//tbody/tr");
                var auditsList = new List<object>();

                if (auditNodes != null)
                {
                    foreach (var auditNode in auditNodes)
                    {
                        
                        var auditRecordNode = auditNode.SelectSingleNode(".//td[1]");
                        var auditIdNode = auditNode.SelectSingleNode(".//td[2]/a[contains(@href, 'Edit')]");

                        
                        var auditData = new
                        {
                            AuditId = auditIdNode?.Attributes["href"]?.Value.Split('/').Last() ?? "N/A",
                            AuditRecord = auditRecordNode?.InnerText?.Trim() ?? "N/A"
                        };

                        auditsList.Add(auditData);
                    }
                }
                else
                {
                    
                    return NotFound(new { message = "No audit records found." });
                }

                
                return Ok(auditsList);
            }
            else
            {
                
                return StatusCode((int)response.StatusCode, new { message = "Error fetching audits", details = response.Content });
            }
        }






    }







}
