using LibraryClass;
using BinaryTree;
namespace TestMyTree
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_Parameterized()
        {
            // Arrange
            int data = 10;

            // Act
            Point<int> point = new Point<int>(data);

            // Assert
            Assert.AreEqual(data, point.Data);
            Assert.IsNull(point.Left);
            Assert.IsNull(point.Right);
        }

        [TestMethod]
        public void ToString_WhenDataIsNotNull_ReturnsDataToString()
        {
            // Arrange
            int data = 10;
            Point<int> point = new Point<int>(data);

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual(data.ToString(), result);
        }

        [TestMethod]
        public void CompareTo_SameData_ReturnsZero()
        {
            // Arrange
            int data = 10;
            Point<int> point1 = new Point<int>(data);
            Point<int> point2 = new Point<int>(data);

            // Act
            int result = point1.CompareTo(point2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareTo_LessThanOther_ReturnsNegative()
        {
            // Arrange
            int data1 = 5;
            int data2 = 10;
            Point<int> point1 = new Point<int>(data1);
            Point<int> point2 = new Point<int>(data2);

            // Act
            int result = point1.CompareTo(point2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_GreaterThanOther_ReturnsPositive()
        {
            // Arrange
            int data1 = 10;
            int data2 = 5;
            Point<int> point1 = new Point<int>(data1);
            Point<int> point2 = new Point<int>(data2);

            // Act
            int result = point1.CompareTo(point2);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void LeftProperty_Setter_SetsLeftCorrectly()
        {
            // Arrange
            Point<int> point1 = new Point<int>();
            Point<int> point2 = new Point<int>();

            // Act
            point1.Left = point2;

            // Assert
            Assert.AreEqual(point2, point1.Left);
        }

        [TestMethod]
        public void RightProperty_Setter_SetsRightCorrectly()
        {
            // Arrange
            Point<int> point1 = new Point<int>();
            Point<int> point2 = new Point<int>();

            // Act
            point1.Right = point2;

            // Assert
            Assert.AreEqual(point2, point1.Right);
        }

        [TestMethod]
        public void CalculateAverageDate_EmptyTree_ReturnsZero()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(0);

            // Act
            double averageDate = tree.CalculateAverageDate();

            // Assert
            Assert.AreEqual(0, averageDate);
        }

        [TestMethod]
        public void CalculateAverageDate_MultipleNodes_ReturnsCorrectAverage()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(3);
            tree.root.Data.Date = 1000;
            tree.root.Left.Data.Date = 2000;
            tree.root.Right.Data.Date = 3000;

            // Act
            double result = tree.CalculateAverageDate();

            // Assert
            Assert.AreEqual(2000, result);
        }

        [TestMethod]
        public void MakeTree_ReturnsNull_WhenLengthIsZero()
        {
            // Arrange
            int length = 0;
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(length);

            // Act
            var result = binaryTree.MakeTree(length, null);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void MakeTree_ReturnsSingleNode_WhenLengthIsOne()
        {
            // Arrange
            int length = 1;
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(length);

            // Act
            var result = binaryTree.MakeTree(length, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Left);
            Assert.IsNull(result.Right);
        }

        [TestMethod]
        public void MakeTree_ReturnsBalancedTree_WhenLengthIsEven()
        {
            // Arrange
            int length = 6; // Even length
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(length);

            // Act
            var result = binaryTree.MakeTree(length, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Left);
            Assert.IsNotNull(result.Right);
        }

        [TestMethod]
        public void MakeTree_ReturnsBalancedTree_WhenLengthIsOdd()
        {
            // Arrange
            int length = 7; // Odd length
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(length);

            // Act
            var result = binaryTree.MakeTree(length, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Left);
            Assert.IsNotNull(result.Right);
        }

        [TestMethod]
        public void AddPoint_AddsData_WhenTreeIsEmpty()
        {
            // Arrange
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(3);
            BankCard data = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };

            // Act
            binaryTree.AddPoint(data);

            // Assert
            Assert.IsTrue(binaryTree.Contains(data));
        }

        [TestMethod]
        public void AddPoint_DoesNotAddData_WhenDataExistsInTree()
        {
            // Arrange
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(3);
            BankCard existingData = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            binaryTree.AddPoint(existingData);

            // Act
            binaryTree.AddPoint(existingData);

            // Assert
            Assert.AreEqual(4, binaryTree.Count);
        }

        [TestMethod]
        public void AddPoint_AddsDataToCorrectLocation()
        {
            // Arrange
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(3);
            BankCard rootData = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            binaryTree.AddPoint(rootData);
            BankCard leftData = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 };
            BankCard rightData = new BankCard { Number = "567890123", Owner = "Alice Johnson", Date = 2023 };

            // Act
            binaryTree.AddPoint(leftData);
            binaryTree.AddPoint(rightData);

            // Assert
            Assert.IsTrue(binaryTree.Contains(leftData));
            Assert.IsTrue(binaryTree.Contains(rightData));
        }

        [TestMethod]
        public void DeleteTree_RemovesAllNodesFromTree()
        {
            // Arrange
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(3);
            binaryTree.AddPoint(new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 });
            binaryTree.AddPoint(new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 });
            binaryTree.AddPoint(new BankCard { Number = "567890123", Owner = "Alice Johnson", Date = 2023 });

            // Act
            binaryTree.DeleteTree();

            // Assert
            Assert.AreEqual(0, binaryTree.Count);
            Assert.IsNull(binaryTree.root);
        }

        [TestMethod]
        public void DeleteNode_RemovesAllNodesRecursively()
        {
            // Arrange
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(3);
            binaryTree.AddPoint(new BankCard { Number = "123456789", Owner = "John Doe", Date = 20230501 });
            binaryTree.AddPoint(new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 20230502 });
            binaryTree.AddPoint(new BankCard { Number = "567890123", Owner = "Alice Johnson", Date = 20230503 });

            // Act
            binaryTree.DeleteNode(binaryTree.root);

            // Assert
            Assert.AreEqual(6, binaryTree.Count);
        }

        public bool AreTreesEqual(MyTree<BankCard> tree1, MyTree<BankCard> tree2)
        {
            return AreSubtreesEqual(tree1.root, tree2.root);
        }

        public bool AreSubtreesEqual(Point<BankCard> node1, Point<BankCard> node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 == null || node2 == null) return false;
            if (!node1.Data.Equals(node2.Data)) return false;
            return AreSubtreesEqual(node1.Left, node2.Left) && AreSubtreesEqual(node1.Right, node2.Right);
        }

        [TestMethod]
        public void Clone_ShouldReturnExactCopyOfTree()
        {
            // Arrange
            MyTree<BankCard> originalTree = new MyTree<BankCard>(2);
            originalTree.AddPoint(new BankCard { Number = "1234", Owner = "Владимир Мономах", Date = 2024 });
            originalTree.AddPoint(new BankCard { Number = "4567", Owner = "Владимир КрасноСолнышко", Date = 2021 });

            // Act
            var clonedTree = originalTree.Clone();

            // Assert
            Assert.IsNotNull(clonedTree);
            Assert.AreNotSame(originalTree, clonedTree);
            Assert.IsTrue(AreTreesEqual(originalTree, clonedTree));
        }

        [TestMethod]
        public void Clone_ShouldReturnNullForEmptyTree()
        {
            // Arrange
            MyTree<BankCard> originalTree = new MyTree<BankCard>(0);

            // Act
            var clonedTree = originalTree.Clone();

            // Assert
            Assert.IsNull(clonedTree.root);
            Assert.AreEqual(0, clonedTree.Count);
        }

        [TestMethod]
        public void Contains_ReturnsFalseForNonExistentData()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(3);
            BankCard existingData = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            BankCard nonExistentData = new BankCard { Number = "987654321", Owner = "Jane Doe", Date = 2023 };
            tree.AddPoint(existingData);

            // Act
            var result = tree.Contains(nonExistentData);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddPoint_AddsDataToLeftAndRightNodes()
        {
            // Arrange
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(0);
            BankCard rootData = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            BankCard leftData = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 };
            BankCard rightData = new BankCard { Number = "567890123", Owner = "Alice Johnson", Date = 2023 };

            // Act
            binaryTree.AddPoint(rootData);
            binaryTree.AddPoint(leftData);
            binaryTree.AddPoint(rightData);

            // Assert
            Assert.AreEqual(rootData, binaryTree.root.Data);
            Assert.AreEqual(leftData, binaryTree.root.Left.Data);
            Assert.AreEqual(rightData, binaryTree.root.Right.Data);
        }

        [TestMethod]
        public void CalculateAverageDate_SingleNode_ReturnsDate()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(1);
            BankCard singleNode = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            tree.root.Data = singleNode;

            // Act
            double result = tree.CalculateAverageDate();

            // Assert
            Assert.AreEqual(singleNode.Date, result);
        }

        [TestMethod]
        public void ShowTree_EmptyTree_ShouldNotThrowException()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(0);

            // Act and Assert
            try
            {
                tree.ShowTree();
            }
            catch
            {
                Assert.Fail("ShowTree method threw an exception on an empty tree.");
            }
        }

        [TestMethod]
        public void DeleteNode_RemovesMiddleNodeCorrectly()
        {
            // Arrange
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(0);
            BankCard data1 = new BankCard { Number = "123", Owner = "John Doe", Date = 20230501 };
            BankCard data2 = new BankCard { Number = "456", Owner = "Jane Smith", Date = 20230601 };
            BankCard data3 = new BankCard { Number = "789", Owner = "Alice Johnson", Date = 20230701 };

            binaryTree.AddPoint(data1);
            binaryTree.AddPoint(data2);
            binaryTree.AddPoint(data3);

            // Act
            binaryTree.DeleteNode(binaryTree.root.Left);

            // Assert
            Assert.IsFalse(binaryTree.Contains(data2));
            Assert.IsTrue(binaryTree.Contains(data1));
            Assert.IsTrue(binaryTree.Contains(data3));
        }

        [TestMethod]
        public void Contains_ReturnsTrueForRootData()
        {
            // Arrange
            MyTree<BankCard> binaryTree = new MyTree<BankCard>(0);
            BankCard data = new BankCard { Number = "123456789", Owner = "John Doe", Date = 20230501 };
            binaryTree.AddPoint(data);

            // Act
            bool result = binaryTree.Contains(data);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MakeTree_GeneratesBalancedTree()
        {
            // Arrange
            int length = 7;
            MyTree<BankCard> tree = new MyTree<BankCard>(length);

            // Act
            var root = tree.MakeTree(length, null);

            // Assert
            Assert.IsNotNull(root);
            Assert.AreEqual(7, CountNodes(root));
        }

        private int CountNodes(Point<BankCard> node)
        {
            if (node == null) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
    }
}