using System;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class RoleAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _rol;

        public RoleAuthenticationFilter(string rol)
        {
            this._rol = rol;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string headerAuthorization = context.HttpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(headerAuthorization))
            {
                var restaurantLogic = this.GetRestaurantLogic(context);

                bool isCorrectHeader = true /*llamar a la logica de chequear validacion de headerAuthorization*/;

                if (isCorrectHeader)
                {
                    User userLogged = new User
                    {
                        Rol = "Admin"
                    };
                        /*llamar a la logica para obtener el usuario a partir del header Authorization*/;

                    if (!(userLogged is null))
                    {
                        bool hasPermission = userLogged.HasPermission(this._rol);

                        if (hasPermission)
                        {
                            /*
                            Haces algo
                            */
                        }
                        else
                        {
                            context.Result = new ContentResult
                            {
                                StatusCode = 403,
                                ContentType = "application/json",
                                Content = "No tenes permisos"
                            };
                        }
                    }
                    else
                    {
                        context.Result = new ContentResult
                        {
                            StatusCode = 401,
                            ContentType = "application/json",
                            Content = "Invalido header Authorization"
                        };
                    }
                }
                else
                {
                    context.Result = new ContentResult
                    {
                        StatusCode = 401,
                        ContentType = "application/json",
                        Content = "Invalido header Authorization"
                    };
                }
            }
            else
            {
                context.Result = new ContentResult
                {
                    StatusCode = 401,
                    ContentType = "application/json",
                    Content = "No estas autenticado"
                };
            }
        }

        private IRestaurantLogic GetRestaurantLogic(AuthorizationFilterContext context)
        {
            var restaurantLogicType = typeof(IRestaurantLogic);
            object restaurantLogicObject = context.HttpContext.RequestServices.GetService(restaurantLogicType);
            var restaurantLogic = restaurantLogicObject as IRestaurantLogic;

            return restaurantLogic;
        }
    }
}