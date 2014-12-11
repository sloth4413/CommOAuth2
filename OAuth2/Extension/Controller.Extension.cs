using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth2.MessageHandler;
using OAuth2.Sina;

namespace OAuth2.Extension
{
    static public class Controller
    {
        public static void RegisterHandler<TContent>(this HandlerController controller,IOAuthHandler<TContent> handler) 
            where TContent : ContextBase
        {
            controller.Controller.Add(typeof(TContent),handler);
        }

        public static IOAuthHandler<TContent> ResolveHandler<TContent>(this HandlerController controller)
            where TContent : ContextBase
        {
            object content;
            controller.Controller.TryGetValue(typeof(TContent),out content);
            return content as IOAuthHandler<TContent>;
        }
    }
}
