﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOfDarksky_Bence_Szalma.Interfaces
{
    public interface IDataService<T> 
    {
        Task<IEnumerable<T>> GetData();
        //void RemoveElement(T item);
    }
}
