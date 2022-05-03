using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
 //#nullable disable

namespace DiskInventory.Models
{
    public partial class Disk
    {
        public Disk()
        {
            //DiskHasArtists = new HashSet<DiskHasArtist>();
            DiskHasBorrowers = new HashSet<DiskHasBorrower>();
        }

        public int DiskId { get; set; }
        [Required(ErrorMessage = "Please enter a disk name.")]
        public string DiskName { get; set; }
        [Required(ErrorMessage = "Please enter a release date.")]

        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Please choose a genre.")]

        public int? GenreId { get; set; }
        [Required(ErrorMessage = "Please choose a status.")]

        public int? StatusId { get; set; }
        [Required(ErrorMessage = "Please enter a disk type.")]

        public int? DiskTypeId { get; set; }

        public virtual DiskType DiskType { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Status Status { get; set; }
        //public virtual ICollection<DiskHasArtist> DiskHasArtists { get; set; }
        public virtual ICollection<DiskHasBorrower> DiskHasBorrowers { get; set; }
    }
}
