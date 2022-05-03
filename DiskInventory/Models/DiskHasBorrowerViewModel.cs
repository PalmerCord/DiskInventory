using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DiskInventory.Models
{
    public partial class DiskHasBorrowerViewModel
    {

        public DiskHasBorrowerViewModel()
        {
            CurrentVM = new DiskHasBorrower();
        }

        public virtual Borrower Borrower { get; set; }
        public virtual Disk Disk { get; set; }
        public List<Borrower> Borrowers { get; set; }
        public List<Disk> Disks { get; set; }
        public DiskHasBorrower CurrentVM { get; set; }
    }
}