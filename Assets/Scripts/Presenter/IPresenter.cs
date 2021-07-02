namespace Fighter.Presenter {
    public interface IPresenter {
        public void Initialize();
        public void Respawn(Model.Model model);
        public void Update();
    }
}