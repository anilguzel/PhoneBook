using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.Business.Abstract
{
    public interface IAccountService
    {
        Account GetByUserNameAndPassword(string userName, string password);
        Account UpdatePassword(Account account);

    }
}
