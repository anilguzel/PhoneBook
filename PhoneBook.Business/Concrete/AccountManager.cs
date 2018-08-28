using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Business.Abstract;
using PhoneBook.Core.Entities.Concrete;
using PhoneBook.DataAccess.Abstract;

namespace PhoneBook.Business.Concrete
{
    public class AccountManager: IAccountService
    {
        private IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public Account GetByUserNameAndPassword(string userName, string password)
        {
            return _accountDal.Get(x => x.UserName == userName & x.Password == password);
        }

        public Account UpdatePassword(Account account)
        {
            return _accountDal.Update(account);
        }
    }
}
