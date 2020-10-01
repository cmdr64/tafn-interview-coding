using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1_Hops
{
    [TestClass]
    public class HopsProblem
    {
        static bool OutOfBounds( int max, int next ) => next < 0 || next >= max;
        static bool CheckPath( int   start,
                               int   goal,
                               int   maxSub,
                               int[] path )
        {
            var pos = start;
            foreach( var node in path )
            {
                var next = pos + node;
                if( OutOfBounds( maxSub, next ) )
                    return false;
                pos = next;
            }
            return pos == goal;
        }

        //very naive and inefficient 
        static void GenTree( Tree<int> t, int[] hops, int depth )
        {
            if( depth == 0 )
                return;
            foreach( var hop in hops )
                GenTree( t.Add( hop ), hops, depth - 1 );
        }

        static IEnumerable<Tree<T>> GetLeaves<T>( Tree<T> t )
        {
            var leaves = new List<Tree<T>>();
            foreach( var node in t.Nodes.Values )
            {
                var cur = node;
                if( cur.Nodes != null )
                {
                    leaves.AddRange( GetLeaves<T>( node ) );
                    continue;
                }
                leaves.Add( node );
            }
            return leaves;
        }

        void PrintPathToRoot( int start, List<int> hops )
        {
            Console.Write( "    " );
            Console.Write( String.Join( " + ", hops.ToArray() ) );
            Console.WriteLine( " = {0}", start + hops.Sum() );
        }

        List<T> GetPathToRoot<T>( Tree<T> node )
        {
            var cur = node;
            var hops = new List<T>();
            while( cur.Par != null )
            {
                hops.Add( cur.Val );
                cur = cur.Par;
            }
            hops.Reverse();
            return hops;
        }

        [TestMethod]
        public void Hops()
        {
            const int arrSize = 4;
            var       res     = new int[arrSize];
            var       hops    = new int[] { -2, -1, 1, 2 };
            const int maxHops = 3;
            const int start   = 1;

            for( var goal = 0; goal < arrSize; goal++ )
            {
                var t = new Tree<int>( 0 );
                GenTree( t, hops, maxHops );
                var leaves = GetLeaves( t );
                foreach( var leaf in leaves )
                {
                    var pathToRoot = GetPathToRoot( leaf );
                    var valid = CheckPath( start, goal, arrSize, pathToRoot.ToArray() );
                    if( valid )
                    {
                        res[goal] += 1;
                        //PrintPathToRoot( start, pathToRoot );
                    }
                }
                Console.WriteLine( "To " + goal + " from " + start + " has " + res[goal] + " solutions" );
            }
        }
    }
}
