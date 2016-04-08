using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace DarwinsFinches
{
    public class Camera
    {
        Matrix view;
        Matrix centerTranslation;
        Matrix zoomMatrix;
        Vector2 target;
        Vector2 position;
        Rectangle levelBounds;

        float zoom;
        float zoomTarget;

        public Camera(Vector2 Position, Rectangle Boundary){
            position = Position;
            zoom = zoomTarget = 1;
            centerTranslation = Matrix.CreateTranslation(
                Game1.graphics.PreferredBackBufferWidth * .5f, 
                Game1.graphics.PreferredBackBufferHeight * .5f, 0);
            levelBounds = new Rectangle(Boundary.Left   + (int)centerTranslation.Translation.X,
                                        Boundary.Top    + (int)centerTranslation.Translation.Y,
                                        Boundary.Right  - (int)centerTranslation.Translation.X*2,
                                        Boundary.Bottom - (int)centerTranslation.Translation.Y*2);
            
            zoomMatrix = Matrix.CreateScale(zoom, zoom, 1);
        }

        public void SetTarget(Vector2 Target){
            target.X = Target.X;
            target.Y = Target.Y;
        }

        public void Update() {
            position += Movement.Approach(position, target, .5f);

            if (zoom != zoomTarget)
            {
                zoom += Movement.Approach(zoom, zoomTarget, .1f);
                if (Math.Abs(zoom - zoomTarget) < .0001) zoom = zoomTarget;
                zoomMatrix = Matrix.CreateScale(zoom, zoom, 1);
            }

            position.X = MathHelper.Clamp(position.X, levelBounds.Left, levelBounds.Right );
            position.Y = MathHelper.Clamp(position.Y, levelBounds.Top , levelBounds.Bottom);

            view = Matrix.CreateTranslation(new Vector3(-position.X,-position.Y,0))*zoomMatrix*centerTranslation;
        }

        public void Zoom(float Value){
            zoomTarget = MathHelper.Clamp(Value,1,5);
        }

        public Matrix View() {
            return view;
        }

    }
}
