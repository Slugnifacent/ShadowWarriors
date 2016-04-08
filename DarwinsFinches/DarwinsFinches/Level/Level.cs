using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarwinsFinches
{
    public class Level
    {

        public class ObjectLocation
        {
            public Vector2 position;
            public int index;
            public GameObject item;
            public ObjectLocation(Vector2 Position, int ListIndex, GameObject Item)
            {
                position = Position;
                index = ListIndex;
                item = Item;
            }
        }

        List<ObjectLocation> objectLocations;
        public List<Enemy> enemyList;
        int width;
        int height;
        int cellSize;

        public Level(int Width, int Height, int CellSize)
        {
            width = Width;
            height = Height;
            cellSize = CellSize;
            objectLocations = new List<ObjectLocation>();
            enemyList = new List<Enemy>();
        }

        public void Update()
        {
            for (int index = 0; index < objectLocations.Count(); index++)
            {
                GameObject current = objectLocations.ElementAt<ObjectLocation>(index).item;
                if (!current.Dead())
                {
                    current.Update();
                }
                else
                {
                    DeleteGameObject(current);
                    index--;
                }
            }
        }

        public bool InsertGameObject(GameObject Item)
        {
            Vector2 tempCoord = Vector2.Zero;
            WorldMapCoordinates(Item.kinetics.position, out tempCoord);
            objectLocations.Add(new ObjectLocation(tempCoord, 0, Item));
            return true;
        }

        public bool DeleteGameObject(GameObject Item)
        {
            for (int index = 0; index < objectLocations.Count(); index++)
            {
                if (objectLocations[index].item.Equals(Item))
                {
                    objectLocations.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }

        public bool WithinWorld(Vector2 Position)
        {
            if (Position.X < 0 || Position.X > width || Position.Y < 0 || Position.Y > height)
            {
                return false;
            }
            return true;
        }

        public void InsertEnemy(Enemy Item)
        {
            InsertGameObject(Item);
            enemyList.Add(Item);
        }

        public List<Enemy> GetEnemyList()
        {
            return enemyList;
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (ObjectLocation location in objectLocations)
            {
                location.item.Draw(batch);
            }
        }

        public void WorldMapCoordinates(Vector2 Position, out Vector2 Coordinate)
        {
            Coordinate.X = (int)Position.X / cellSize;
            Coordinate.Y = (int)Position.Y / cellSize;
        }

        public void MapWorldCoordinates(Vector2 Coordinate, out Vector2 Position)
        {
            Position.X = Coordinate.X * cellSize;
            Position.Y = Coordinate.Y * cellSize;
        }

        public void Collision()
        {
            for (int index = 0; index < objectLocations.Count; index++)
            {
                GameObject Item = objectLocations.ElementAt<ObjectLocation>(index).item;
                for (int endex = index + 1; endex < objectLocations.Count; endex++)
                {
                    GameObject Etem = objectLocations.ElementAt<ObjectLocation>(endex).item;
                    if (Item.kinetics.boundingBox.Intersects(Etem.kinetics.boundingBox))
                    {
                        Item.CollisionResolution(Etem);
                        Etem.CollisionResolution(Item);
                    }
                }
            }
        }
    }
}
