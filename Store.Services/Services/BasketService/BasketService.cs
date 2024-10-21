using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Store.Repository.Basket.Interfaces;
using Store.Repository.Basket.Models;
using Store.Services.Services.BasketService.Dtos;

namespace Store.Services.Services.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository , IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        => await _basketRepository.DeleteBasketAsync(basketId); 

        public async Task<CustomerBasketDto> GetBasketAsync(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);

            if (basket == null)
                return new CustomerBasketDto();

            var mappedBaskets = _mapper.Map<CustomerBasketDto>(basket);
            return mappedBaskets;
        }

        public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto input)
        {
            if (input.Id is null) 
                input.Id = GenerateRandomBasketId();

            var customerBasket = _mapper.Map<CustomerBasket>(input);
            var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket);
            var mappedUpdateBasket = _mapper.Map<CustomerBasketDto>(updatedBasket);

            return mappedUpdateBasket;

        }
        private string GenerateRandomBasketId()
        {
            Random random = new Random();
            int randomDigits = random.Next(1000, 10000);

            return $"BS-{randomDigits}";
           
        }

    }
}
