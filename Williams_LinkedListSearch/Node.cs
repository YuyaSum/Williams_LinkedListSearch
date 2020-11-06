using System;
using System.Collections.Generic;
using System.Text;

namespace Williams_LinkedListSearch
{
    class Node
    {
        public Node Previous;
        public Node Next;
        public MetaData Data;
        public Node(MetaData data)
        {
            Next = null;
            Previous = null;
            Data = data;
        }
    }
}
