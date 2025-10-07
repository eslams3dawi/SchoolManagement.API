using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Email.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Email.Commands.Handlers
{
    public class EmailCommandHandler : ResponseHandler,
                                       IRequestHandler<SendEmailCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IEmailService _emailService;

        public EmailCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IEmailService emailService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _emailService = emailService;
        }

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _emailService.SendEmailAsync(request.Email, request.Subject, request.Message);
            if (result == "Email Sent Successfully")
                return Success<string>(null, null, _stringLocalizer[SharedResourcesKeys.EmailSentSuccessfully]);

            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToSendEmail]);
        }
    }
}
