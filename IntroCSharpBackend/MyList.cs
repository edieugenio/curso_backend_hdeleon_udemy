﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroCSharpBackend
{
    internal class MyList<T>
    {
        private List<T> _list;
        private int _limit;

        public MyList(int limit)
        {
            _limit = limit;
            _list = new List<T>();
        }

        public void Add(T item)
        {
            if (_list.Count < _limit) 
            {
                _list.Add(item);
            }
        }

        public string GetContent()
        {
            string content = "";
            foreach( var item in _list)
            {
                content += item + ",";
            }
            return content;
        }

    }
}
