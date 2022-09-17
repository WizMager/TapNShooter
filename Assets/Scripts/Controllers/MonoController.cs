using System.Collections.Generic;
using Controllers.Interfaces;

namespace Controllers
{
    public class MonoController : IAwake, IStart, IEnable, IUpdate, IFixedUpdate, IDisable, IDestroy
    {
        private readonly List<IAwake> _awakes;
        private readonly List<IStart> _starts;
        private readonly List<IEnable> _enables;
        private readonly List<IUpdate> _updates;
        private readonly List<IFixedUpdate> _fixedUpdates;
        private readonly List<IDisable> _disables;
        private readonly List<IDestroy> _destroys;

        public MonoController()
        {
            _awakes = new List<IAwake>();
            _starts = new List<IStart>();
            _enables = new List<IEnable>();
            _updates = new List<IUpdate>();
            _fixedUpdates = new List<IFixedUpdate>();
            _disables = new List<IDisable>();
            _destroys = new List<IDestroy>();
        }

        internal MonoController Add(IController controller)
        {
            if (controller is IAwake awake)
            {
                _awakes.Add(awake);
            }

            if (controller is IStart start)
            {
                _starts.Add(start);
            }

            if (controller is IEnable enable)
            {
              _enables.Add(enable);  
            }

            if (controller is IUpdate update)
            {
                _updates.Add(update);
            }

            if (controller is IFixedUpdate fixedUpdate)
            {
                _fixedUpdates.Add(fixedUpdate);
            }

            if (controller is IDisable disable)
            {
               _disables.Add(disable); 
            }

            if (controller is IDestroy destroy)
            {
                _destroys.Add(destroy);
            }

            return this;
        }
        
        internal MonoController Remove(IController controller)
        {
            if (controller is IAwake awake)
            {
                _awakes.Remove(awake);
            }

            if (controller is IStart start)
            {
                _starts.Remove(start);
            }

            if (controller is IEnable enable)
            {
                _enables.Remove(enable);  
            }

            if (controller is IUpdate update)
            {
                _updates.Remove(update);
            }

            if (controller is IFixedUpdate fixedUpdate)
            {
                _fixedUpdates.Remove(fixedUpdate);
            }

            if (controller is IDisable disable)
            {
                _disables.Remove(disable); 
            }

            if (controller is IDestroy destroy)
            {
                _destroys.Remove(destroy);
            }

            return this;
        }
        
        public void Awake()
        {
            _awakes.ForEach(awake => awake.Awake());
        }

        public void Start()
        {
            _starts.ForEach(start => start.Start());
        }

        public void OnEnable()
        {
            _enables.ForEach(enable => enable.OnEnable());
        }

        public void Update()
        {
           _updates.ForEach(update => update.Update()); 
        }

        public void FixedUpdate()
        {
            _fixedUpdates.ForEach(fixedUpdate => fixedUpdate.FixedUpdate());
        }

        public void OnDisable()
        {
            _disables.ForEach(disable => disable.OnDisable());
        }

        public void OnDestroy()
        {
          _destroys.ForEach(destroy => destroy.OnDestroy());  
        }
    }
}