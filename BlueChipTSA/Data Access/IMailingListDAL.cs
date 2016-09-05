using BlueChipTSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueChipTSA.Data_Access
{
    public interface IMailingListDAL
    {
        List<NewEmail> GetAllEmailAddresses();
        bool AddEmail(NewEmail newEmail);
    }
}
