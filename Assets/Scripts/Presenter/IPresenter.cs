namespace Fighter.Presenter {
    public interface IPresenter {
        public void Initialize();
        public void Respawn(int id, Model.Model model);
        public void Update();
    }
}