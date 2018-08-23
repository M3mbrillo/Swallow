using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SwallowCore.Models.Base
{
    public interface IUserOwner
    {
        [Column("User_Id")]
        int UserId { get; set; }
    }
}
