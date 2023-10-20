using Medilo.API.Models.DTO;
using Medilo.API.Models;
using Medilo.API.Repositories.Contracts;
using System.Transactions;
using AutoMapper;

namespace Medilo.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<Person> AddPersonWithAddress(PersonAddressDto personAddress)
        {
            using var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            }, TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                PersonDto personDto = personAddress.Person;

                int addressId = await GetAddressId(personAddress);
                Person person = _mapper.Map<Person>(personDto);
                person.AddressId = addressId;

                Person newPerson = await _personRepository.AddAsync(person);

                transaction.Complete();

                return newPerson;
            }
            catch (Exception)
            {
                transaction.Dispose();
                return null;
            }
        }

        public async Task UpdatePersonWithAddress(int id, PersonAddressDto personAddress)
        {
            using var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            }, TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                Person person = await _personRepository.GetAsync(id);
                Console.WriteLine("2");
                if (person != null)
                {
                    PersonDto personDto = personAddress.Person;

                    person.Name = personDto.Name;
                    person.Surname = personDto.Surname;
                    person.PhoneNumber = personDto.PhoneNumber;
                    person.BirthDate = personDto.BirthDate;

                    int addressId = await GetAddressId(personAddress);
                    person.AddressId = addressId;

                    await _personRepository.UpdateAsync(person);

                    transaction.Complete();

                }
            }
            catch (Exception)
            {
                transaction.Dispose();
            }
        }

        private async Task<int> GetAddressId(PersonAddressDto personAddress)
        {
            AddressDto addressDto = personAddress.Address;

            Address address = _mapper.Map<Address>(addressDto);

            Address existedAddress = await _addressRepository.AddressExist(address);
            int addressId;

            if (existedAddress == null)
            {
                Address newAddress = await _addressRepository.AddAsync(address);
                addressId = newAddress.Id;
            }
            else addressId = existedAddress.Id;

            return addressId;
        }
    }
}
