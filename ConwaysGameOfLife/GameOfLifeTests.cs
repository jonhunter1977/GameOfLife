using System.Collections.Generic;
using NUnit.Framework;

namespace ConwaysGameOfLife
{
    [TestFixture]
    public class CellTests1 : ICellCollection
    {
        private List<Cell> _neighbouringCells = new List<Cell>()
            {
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
            };

        public List<Cell> NeighbouringCells
        {
            get { return _neighbouringCells; }
            set { throw new System.NotImplementedException(); }
        }

        [Test]
        public void A_Cell_With_One_Live_Neighbour_Dies()
        {
            var cell = new Cell(this);
            cell.CountAliveNeighbours();
            cell.WorkOutLifeStatus();
            Assert.AreEqual(cell.CellStatus, CellStatus.Dead);
        }

        public int CountNumberOfAliveCellsInCollection()
        {
            return _neighbouringCells.FindAll(n => n.CellStatus == CellStatus.Alive).Count;
        }
    }

    [TestFixture]
    public class CellTests2 : ICellCollection
    {
        private readonly List<Cell> _neighbouringCells = new List<Cell>()
            {
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
            };

        public List<Cell> NeighbouringCells
        {
            get { return _neighbouringCells; }
        }

        [Test]
        public void A_Cell_With_Two_Live_Neighbours_Lives()
        {
            var cell = new Cell(this);
            cell.CountAliveNeighbours();
            cell.WorkOutLifeStatus();
            Assert.AreEqual(cell.CellStatus, CellStatus.Alive);
        }

        public int CountNumberOfAliveCellsInCollection()
        {
            return _neighbouringCells.FindAll(n => n.CellStatus == CellStatus.Alive).Count;
        }
    }

    [TestFixture]
    public class CellTests3 : ICellCollection
    {
        private readonly List<Cell> _neighbouringCells = new List<Cell>()
            {
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
            };

        public List<Cell> NeighbouringCells
        {
            get { return _neighbouringCells; }
        }

        [Test]
        public void A_Cell_With_Three_Live_Neighbours_Lives()
        {
            var cell = new Cell(this);
            cell.CountAliveNeighbours();
            cell.WorkOutLifeStatus();
            Assert.AreEqual(cell.CellStatus, CellStatus.Alive);
        }

        public int CountNumberOfAliveCellsInCollection()
        {
            return _neighbouringCells.FindAll(n => n.CellStatus == CellStatus.Alive).Count;
        }
    }

    [TestFixture]
    public class CellTests4 : ICellCollection
    {
        private readonly List<Cell> _neighbouringCells = new List<Cell>()
            {
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Alive),
                new Cell(CellStatus.Dead),
            };

        public List<Cell> NeighbouringCells
        {
            get { return _neighbouringCells; }
        }

        [Test]
        public void A_Cell_With_Four_Live_Neighbours_Dies()
        {
            var cell = new Cell(this);
            cell.CountAliveNeighbours();
            cell.WorkOutLifeStatus();
            Assert.AreEqual(cell.CellStatus, CellStatus.Dead);
        }

        public int CountNumberOfAliveCellsInCollection()
        {
            return _neighbouringCells.FindAll(n => n.CellStatus == CellStatus.Alive).Count;
        }
    }

    [TestFixture]
    public class CellTests5 : ICellCollection
    {
        private readonly List<Cell> _neighbouringCells = new List<Cell>()
            {
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
                new Cell(CellStatus.Dead),
            };

        public List<Cell> NeighbouringCells
        {
            get { return _neighbouringCells; }
        }

        [Test]
        public void A_Cell_With_No_Live_Neighbours_Comes_Alive()
        {
            var cell = new Cell(this);
            cell.CountAliveNeighbours();
            cell.WorkOutLifeStatus();
            Assert.AreEqual(cell.CellStatus, CellStatus.Alive);
        }

        public int CountNumberOfAliveCellsInCollection()
        {
            return _neighbouringCells.FindAll(n => n.CellStatus == CellStatus.Alive).Count;
        }
    }

    public interface ICellCollection
    {
        List<Cell> NeighbouringCells { get;}
        int CountNumberOfAliveCellsInCollection();
    }

    public enum CellStatus
    {
        Alive,
        Dead
    }

    public class Cell
    {
        private readonly ICellCollection _neighbours;
        
        private int _noOfLiveNeighbours;

        private CellStatus _cellStatus;
        public CellStatus CellStatus
        {
            get { return _cellStatus; }
        }

        public Cell(ICellCollection neighbours)
        {
            _neighbours = neighbours;
        }

        public Cell(CellStatus cellStatus)
        {
            _cellStatus = cellStatus;
        }

        public void CountAliveNeighbours()
        {
            _noOfLiveNeighbours = _neighbours.CountNumberOfAliveCellsInCollection();
        }

        public void WorkOutLifeStatus()
        {
            if(_noOfLiveNeighbours != 1 && _noOfLiveNeighbours != 4)
                _cellStatus = CellStatus.Alive;
            else            
                _cellStatus = CellStatus.Dead;            
        }
    }
}
