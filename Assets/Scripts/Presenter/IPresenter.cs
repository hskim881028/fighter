using Fighter.Data;
using UnityEngine;

namespace Fighter.Presenter {
    public interface IPresenter {
        public void Initialize(int id, IData data, Vector3 position, Vector3 direction);
        public void Respawn(IData data, Vector3 position, Vector3 direction);
        public void Update();
        public Model.Model GetModel();
    }
}