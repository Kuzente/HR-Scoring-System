﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Base
{
	public class BaseEntity
	{
		public int ID { get; set; }
		public DateTime CreatedDate { get; set; } 
		public DateTime UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}
