using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Service.Option
{
   public class EntityService
    {
       


        public EntityService()
        {
            _appUserService = new AppUserService();
            _categoryService = new CategoryService();
            _commentService = new CommentService();
            _dislikeService = new DislikeService();
            _ımageForProductsService = new ImageForProductsService();
            _likeService = new LikeService();
            _orderDetailsService = new OrderDetailsService();
            _orderService = new OrderService();
            _productService = new ProductService();
            _treeCommentService = new TreeCommentService();

        }

        private AppUserService _appUserService;

        public AppUserService AppUserService
        {
            get { return _appUserService; }
            set { _appUserService = value; }
        }

        private CategoryService _categoryService;

        public CategoryService CategoryService
        {
            get { return _categoryService; }
            set { _categoryService = value; }
        }

        private CommentService _commentService;

        public CommentService CommentService
        {
            get { return _commentService; }
            set { _commentService = value; }
        }

        private DislikeService _dislikeService;

        public DislikeService DislikeService
        {
            get { return _dislikeService; }
            set { _dislikeService = value; }
        }

        private ImageForProductsService _ımageForProductsService;

        public ImageForProductsService ImageForProductsService
        {
            get { return _ımageForProductsService; }
            set { _ımageForProductsService = value; }
        }

        private LikeService _likeService;

        public LikeService LikeService
        {
            get { return _likeService; }
            set { _likeService = value; }
        }

        private OrderDetailsService _orderDetailsService;

        public OrderDetailsService OrderDetailsService
        {
            get { return _orderDetailsService; }
            set { _orderDetailsService = value; }
        }

        private OrderService _orderService;

        public OrderService OrderService
        {
            get { return _orderService; }
            set { _orderService = value; }
        }

        private ProductService _productService;

        public ProductService ProductService
        {
            get { return _productService; }
            set { _productService = value; }
        }

        private TreeCommentService _treeCommentService;

        public TreeCommentService TreeCommentService
        {
            get { return _treeCommentService; }
            set { _treeCommentService = value; }
        }




    }
}
