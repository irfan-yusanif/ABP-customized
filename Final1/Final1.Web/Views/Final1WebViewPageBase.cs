using Abp.Web.Mvc.Views;

namespace Final1.Web.Views
{
    public abstract class Final1WebViewPageBase : Final1WebViewPageBase<dynamic>
    {

    }

    public abstract class Final1WebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected Final1WebViewPageBase()
        {
            LocalizationSourceName = Final1Consts.LocalizationSourceName;
        }
    }
}