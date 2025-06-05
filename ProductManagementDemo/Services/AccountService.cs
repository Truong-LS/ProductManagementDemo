using BusinessObjects;
using Repositories_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository iAccountRepository;
        public AccountMember GetAccountById(string accountId)
        {
            return iAccountRepository.GetAccountById(accountId);
        }
    }
}
