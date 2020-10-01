using System;
using System.Collections.Generic;

namespace Problem1_Hops {
    class Tree<T>
    {
        public Tree<T>                Par   = null;       //the parent of this node
        public T                      Val   = default(T); //val of this node
        public SortedList<T, Tree<T>> Nodes = null;       //children

        Tree( T val, Tree<T> par )
        {
            Par = par;
            Val = val;
        }

        //only for the root node
        public Tree( T val ) { Val = val; }

        public Tree<T> Add( T c )
        {
            if( Nodes == null )
                Nodes = new SortedList<T, Tree<T>>();
            if( Nodes.ContainsKey( c ) )
                throw new Exception( "could not add child " + c.ToString() );
            Nodes.Add( c, new Tree<T>( c, this ) );
            return Nodes[c];
        }

        //all functions below this line are for debugging 
        static string Pad( int indent ) => "".PadLeft( 4 * indent, ' ' );
        static void Print( Tree<T> t, int indent )
        {
            Console.WriteLine( Pad(indent) + t.Val );
            if( t.Nodes == null )
                return;
            foreach( var child in t.Nodes )
                Print( child.Value, indent + 1 );
        }
        public void Print() => Print( this, 0 );
    }
}