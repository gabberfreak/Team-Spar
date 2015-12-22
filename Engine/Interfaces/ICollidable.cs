using Engine.Models;

namespace Engine.Interfaces
{
    public interface ICollidable
    {
        bool InBoundsX();
        bool InBoundsY();
        bool Intersects(BaseObject obj);
    }
}
