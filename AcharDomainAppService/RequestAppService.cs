﻿using AcharDomainCore.Contracts.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using Microsoft.AspNetCore.Http.Internal;

namespace AcharDomainAppService
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _service;
        public RequestAppService(IRequestService service)
        {
            _service = service;
        }

        public async Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CreateRequest(requestDto, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateRequest: {ex.Message}");
            }
        }

        public async Task<bool> UpdateRequest(RequestUpDto requestUpDto, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateRequest(requestUpDto, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateRequest: {ex.Message}");
            }
        }

        public async Task<int> RequestCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.RequestCount( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error RequestCount: {ex.Message}");
            }
        }

        public async Task<RequestGetDto> GetRequestById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetRequestById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetRequestById: {ex.Message}");
            }
        }

        public async Task<List<RequestGetDto?>> GetRequests(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetRequests( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetRequests: {ex.Message}");
            }
        }

        public async Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteRequest(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteRequest: {ex.Message}");
            }
        }

        public async Task<bool> ChangeRequestStatus(StatusRequestDto newStatus, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.ChangeRequestStatus(newStatus, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UploadImage: {ex.Message}");
            }
        }
    }
}
