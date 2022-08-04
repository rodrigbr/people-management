using FluentValidation.Results;
using MediatR;
using People.Management.Application.Commands;
using People.Management.Domain.Contracts;
using People.Management.Domain.Entites;

namespace People.Management.Application.CommandHandlers
{
    public class UserCommandHandler :
        IRequestHandler<CreateUserCommand, ValidationResult>,
        IRequestHandler<UpdateUserCommand, ValidationResult>,
        IRequestHandler<DeleteUserCommand, ValidationResult>,
        IRequestHandler<UpdateSchoolRecordCommand, ValidationResult>,
        IRequestHandler<DeleteSchoolingCommand, ValidationResult>,
        IRequestHandler<DeleteSchoolRecordCommand, ValidationResult>,
        IRequestHandler<UpdateSchoolingCommand, ValidationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISchoolingRepository _schoolingRepository;
        private readonly ISchoolRecordRepository _schoolRecordRepository;

        public UserCommandHandler(IUserRepository userRepository, ISchoolingRepository schoolingRepository, ISchoolRecordRepository schoolRecordRepository)
        {
            _userRepository = userRepository;
            _schoolingRepository = schoolingRepository;
            _schoolRecordRepository = schoolRecordRepository;
        }

        public async Task<ValidationResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            User user = _userRepository.GetById(request.Id);

            if (user == null)
            {
                request.AddValidationError("Usuário", "Usuário não foi encontrado!");
                return request.ValidationResult;
            }

            user.Update(request.FirstName, request.LastName, request.Email, request.BirthDate, request.Adress,
                request.City, request.Country, request.Number, request.Uf, request.ZipCode);

            if (user.IsValid())
            {
                _userRepository.Update(user);
            }

            return await Task.FromResult(user.ValidationResult);
        }

        public async Task<ValidationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            User user = _userRepository.GetById(request.Id);

            if (user == null)
            {
                request.AddValidationError("Delete", "Usuário não foi encontrado!");
                return request.ValidationResult;
            }

            _userRepository.Remove(user);

            return await Task.FromResult(user.ValidationResult);
        }

        public async Task<ValidationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            User user = new(request.FirstName, request.LastName, request.Email, request.BirthDate, request.Adress,
                request.City, request.Country, request.Number, request.Uf, request.ZipCode);

            if (user.IsValid())
            {
                _userRepository.Add(user);
            }

            return await Task.FromResult(user.ValidationResult);
        }

        public async Task<ValidationResult> Handle(UpdateSchoolingCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdWithSchooling(request.UserId);

            if (user == null)
            {
                request.AddValidationError("Usuário", "Usuário não foi encontrado!");
                return request.ValidationResult;
            }

            if (user.SchoolingId != null)
            {
                _schoolingRepository.Remove(user.Schooling);
            }

            user.AddSchooling(request.SchoolingId);

            if (user.IsValid())
            {
                _userRepository.Update(user);
            }

            return await Task.FromResult(user.ValidationResult);
        }

        public async Task<ValidationResult> Handle(UpdateSchoolRecordCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdWithSchoolRecord(request.UserId);

            if (user == null)
            {
                request.AddValidationError("Usuário", "Usuário não foi encontrado!");
                return request.ValidationResult;
            }

            if (user.SchoolRecordId != null)
            {
                _schoolRecordRepository.Remove(user.SchoolRecord);
            }

            user.AddSchoolRecord(request.Format, request.Name);

            if (user.IsValid())
            {
                _userRepository.Update(user);
            }

            return await Task.FromResult(user.ValidationResult);
        }

        public async Task<ValidationResult> Handle(DeleteSchoolingCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdWithSchooling(request.Id);

            if (user == null)
            {
                request.AddValidationError("Usuário", "Usuário não foi encontrado!");
                return request.ValidationResult;
            }

            _schoolingRepository.Remove(user.Schooling);

            if (user.IsValid())
            {
                _userRepository.Update(user);
            }

            return await Task.FromResult(user.ValidationResult);
        }

        public async Task<ValidationResult> Handle(DeleteSchoolRecordCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdWithSchoolRecord(request.Id);

            if (user == null)
            {
                request.AddValidationError("Usuário", "Usuário não foi encontrado!");
                return request.ValidationResult;
            }

            _schoolRecordRepository.Remove(user.SchoolRecord);
            
            if (user.IsValid())
            {
                _userRepository.Update(user);
            }

            return await Task.FromResult(user.ValidationResult);
        }
    }
}
