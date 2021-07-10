using Fighter.Data;
using UnityEngine;

namespace Fighter.Presenter {
    public interface IPresenter {
        public Model.Model Model { get; }
        public void Initialize(int id, IData data, Vector3 position, Vector3 direction);
        public void Respawn(IData data, Vector3 position, Vector3 direction);
        public void Update();
    }
}