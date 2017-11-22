using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsLikeButton
{
    public partial class MainPage : ContentPage
    {
        private bool _liked;
        private bool _busy;
        private readonly Guid _articleId;

        public MainPage()
        {
            InitializeComponent();

            _liked = false;
            _busy = false;
            _articleId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapLikeImage_Tapped; ;
            likeImg.GestureRecognizers.Add(tapGestureRecognizer);
            SetLikeButtonState();
        }

        private async void TapLikeImage_Tapped(object sender, EventArgs e)
        {
            if (!_busy)
            {                
                try
                {
                    _busy = true;
                    var res = await SetLike(_articleId);
                    _liked = res;
                }
                catch (Exception ex)
                {
                    // TODO: Log? Throw?
                }
                finally
                {
                    _busy = false;
                    SetLikeButtonState();
                }
            }
        }

        private void SetLikeButtonState()
        {
            likeImg.Source = new FileImageSource() { File = _liked ? "unlike.png" : "like.png" };
            likeImg.Opacity = 1.0;           
        }

        public async Task<bool> SetLike(Guid articleId)
        {
            likeImg.Opacity = 0.5;            
            return await SetLikeService(articleId);
        }
        public async Task<bool> SetLikeService(Guid articleId)
        {
            var taskFactory = new TaskFactory();

            await Task.Delay(2000);

            throw new Exception("Error");

            var res = taskFactory.StartNew<bool>(() => !_liked);

            return await res;
        }
    }
}
