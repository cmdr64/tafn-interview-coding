using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1_Hops
{
    [TestClass]
    public class TestTree
    {
        [TestMethod]
        public void AddOneChild()
        {
            var root = new Tree<int>( 0 );
            var t1   = root.Add( 1 );
            Assert.AreNotSame( root, t1 );
            Assert.AreEqual( t1.Val, 1 );
            Assert.IsNull( t1.Nodes );
        }

        [TestMethod]
        public void AddSecondLevel()
        {
            var root  = new Tree<int>( 0 );
            var t1    = root.Add( 1 );
            var t1_t2 = t1.Add( 2 );
            var t1_t3 = t1.Add( 3 );
            var t2    = root.Add( 2 );
            var t2_t3 = t2.Add( 3 );
            root.Print();
        }

        [TestMethod]
        public void TestArbitraryTree()
        {
            var t  = new Tree<int>( 0 );
            var t1 = t.Add( 1 );
            t1.Add( 2 );
            t1.Add( 3 );
            t1.Add( 1 );
            t.Print();
        }
    }
}
