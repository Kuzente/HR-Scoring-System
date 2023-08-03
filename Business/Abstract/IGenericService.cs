﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SamiProje.Business.Abstract
{
	public interface IGenericService<T>
	{
		void TAdd(T entity);
		void TDelete(int id);
		void TUpdate(T entity);
		void ChangeStatus(int id);
        List<T> TGetList();
		T TGetById(int id);
    }
}
