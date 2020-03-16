namespace Asteroid
{
    public class AsteroidPool : GenericPool<Asteroid>
    {
        protected override void Setup()
        {
            InitialCount = 20;
        }
    }
}