namespace Jango.CMS.Domain.Repository
{
    public class RequestPage
    {
        public RequestPage(int pagesize,int currentpage,string orderproperty,string order)
        {
            this.PageSize = pagesize;
            this.CurrentPage = currentpage;
            this.Orderproperty = orderproperty;
            this.Order = order;
        }

        public int PageSize { get; }
        public int CurrentPage { get; }
        public string Orderproperty { get; }
        public string Order { get; }
    }
}