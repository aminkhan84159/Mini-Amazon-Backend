using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.ConfirmCart;

namespace Amazon.Api.Controllers
{
    public class ConfirmCartController(
        ILogger<ConfirmCartController> logger,
        ConfirmCartManager ConfirmCartManager)
        : GenericController<GetConfirmCartRequest, AddConfirmCartRequest, UpdateConfirmCartRequest, DeleteConfirmCartRequest>(logger, ConfirmCartManager)
    { }
}
