﻿using Backend.Dtos;
using System.Globalization;

namespace TippsBackend.Services;

public class OrderService
{
    private readonly ContainerToolDBContext _db;

    public OrderService(ContainerToolDBContext db)
    {
        this._db = db;
    }

    public List<Order> GetAllOrders()
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .ToList();
    }

    public List<Order> GetOrdersWithCustomername(string customerName)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.CustomerName.ToLower().Contains(customerName.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithApprovedByCs(bool approved)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.ApprovedByCrCs == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithApprovedByTl(bool approved)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.ApprovedByCrTl == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithApprovedByPpCs(bool approved)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.ApprovedByPpCs == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithApprovedByPp(bool approved)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.ApprovedByPpPp == approved)
            .ToList();
    }

    public List<Order> GetOrdersWithAmount(int amount)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.Amount == amount)
            .ToList();
    }

    public List<Order> GetOrdersWithCreatedBy(string createdBy)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.CreatedBy.ToLower().Contains(createdBy.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithCountry(string country)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(y => _db.Tlinquiries.Single(x => x.Id == y.Tlid).Country.ToLower().Contains(country.ToLower()))
            .ToList();
    }

    public List<Order> GetOrdersWithSped(string sped)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(y => _db.Tlinquiries.Single(x => x.Id == y.Tlid).Sped.ToLower().Contains(sped.ToLower()))
            .ToList();
    }

    public List<Order>? GetOrdersWithLastUpdated(string date)
    {
        try
        {
            DateTime parsedDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return _db.Orders
                .Include(x => x.Tl)
                .Include(x => x.Cs)
                .Include(x => x.Checklist)
                .OrderBy(x => x.Id)
                .AsEnumerable()
                .Where(x => (x.LastUpdated.Date - parsedDate.Date).Days == 0)
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
    }


    public List<Order> GetOrdersWithStatus(string status)
    {
        return _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .OrderBy(x => x.Id)
            .Where(x => x.Status.ToLower().Contains(status.ToLower()))
            .ToList();
    }

    public Order? GetOrderWithId(int id)
    {
        try
        {
            Order order = _db.Orders
            .Include(x => x.Tl)
            .Include(x => x.Cs)
            .Include(x => x.Checklist)
            .Single(x => x.Id == id);

            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Order? ApproveCrCs(EditApproveOrderDto approveOrderDto)
    {
        try
        {
            var order = _db.Orders
                .Include(x => x.Tl)
                .Include(x => x.Cs)
                .Single(x => x.Id == approveOrderDto.Id);
            order.ApprovedByCrCsTime = DateTime.Now;
            order.ApprovedByCrCs = approveOrderDto.Approve;
            _db.SaveChanges();
            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Order? ApproveCrTl(EditApproveOrderDto approveOrderDto)
    {
        try
        {
            var order = _db.Orders
                .Include(x => x.Tl)
                .Include(x => x.Cs)
                .Single(x => x.Id == approveOrderDto.Id);
            order.ApprovedByCrTlTime = DateTime.Now;
            order.ApprovedByCrTl = approveOrderDto.Approve;
            _db.SaveChanges();
            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Order? ApprovePpCs(EditApproveOrderDto approveOrderDto)
    {
        try
        {
            var order = _db.Orders
                .Include(x => x.Tl)
                .Include(x => x.Cs)
                .Single(x => x.Id == approveOrderDto.Id);
            order.ApprovedByPpCsTime = DateTime.Now;
            order.ApprovedByPpCs = approveOrderDto.Approve;
            _db.SaveChanges();
            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Order? ApprovePpPp(EditApproveOrderDto approveOrderDto)
    {
        try
        {
            var order = _db.Orders
                .Include(x => x.Tl)
                .Include(x => x.Cs)
                .Single(x => x.Id == approveOrderDto.Id);
            order.ApprovedByPpPpTime = DateTime.Now;
            order.ApprovedByPpPp = approveOrderDto.Approve;
            _db.SaveChanges();
            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public OrderDto? AddOrder(AddOrderDto addOrderDto)
    {
        try
        {
            Console.WriteLine("posting Order");
            var checklist = _db.Checklists.Single(x => x.Id == addOrderDto.ChecklistId);
            var cs = _db.Csinquiries.Single(x => x.Id == addOrderDto.Csid);
            var tl = _db.Tlinquiries.Single(x => x.Id == addOrderDto.Tlid);
            var order = new Order
            {
                Amount = addOrderDto.Amount,
                ApprovedByCrCs = false,
                ApprovedByCrTl = false,
                ApprovedByPpCs = false,
                ApprovedByPpPp = false,
                Checklist = checklist,
                ChecklistId = addOrderDto.ChecklistId,
                CreatedBy = addOrderDto.CreatedBy,
                Cs = cs,
                Tl = tl,
                Csid = addOrderDto.Csid,
                CustomerName = addOrderDto.CustomerName,
                LastUpdated = DateTime.Now,
                Status = addOrderDto.Status,
                Tlid = addOrderDto.Tlid,
                AdditionalInformation = addOrderDto.AdditionalInformation,
                ApprovedByCrCsTime = null,
                ApprovedByCrTlTime = null,
                ApprovedByPpCsTime = null,
                ApprovedByPpPpTime = null
            };
            Console.WriteLine(order);

            _db.Orders.Add(order);
            _db.SaveChanges();

            return new OrderDto
            {
                Id = order.Id,
                AbNumber = order.Cs.Abnumber,
                Amount = order.Amount,
                ApprovedByCrCs = order.ApprovedByCrCs,
                ApprovedByCrTl = order.ApprovedByCrTl,
                ApprovedByPpCs = order.ApprovedByPpCs,
                ChecklistId = order.ChecklistId,
                Country = order.Tl.Country,
                CreatedBy = order.CreatedBy,
                Csid = order.Csid,
                CustomerName = order.CustomerName,
                LastUpdated = order.LastUpdated.ToString("dd.MM.yyyy"),
                ReadyToLoad = order.Cs.ReadyToLoad.ToString("dd.MM.yyyy"),
                Sped = order.Tl.Sped,
                Status = order.Status,
                Tlid = order.Tlid,
                AdditionalInformation = order.AdditionalInformation,
                ApprovedByTlTime = order.ApprovedByCrCsTime != null ? order.ApprovedByCrCsTime.Value.ToString("dd.MM.yyyy") : "",
                ApprovedByCsTime = order.ApprovedByCrTlTime != null ? order.ApprovedByCrTlTime.Value.ToString("dd.MM.yyyy") : "",
                ApprovedByPpCsTime = order.ApprovedByPpCsTime != null ? order.ApprovedByPpCsTime.Value.ToString("dd.MM.yyyy") : "",
                ApprovedByPpPpTime = order.ApprovedByPpPpTime != null ? order.ApprovedByPpPpTime.Value.ToString("dd.MM.yyyy") : "",
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public Order EditOrder(EditOrderDto editOrderDto)
    {
        var checklist = _db.Checklists.Single(x => x.Id == editOrderDto.ChecklistId);

        var order = _db.Orders.Include(x => x.Tl).Include(x => x.Cs).Include(x => x.Checklist).Single(x => x.Id == editOrderDto.Id);
        order.ApprovedByCrCs = editOrderDto.ApprovedByCs;
        order.Checklist = checklist;
        order.ChecklistId = editOrderDto.ChecklistId;
        order.Amount = editOrderDto.Amount;
        order.CreatedBy = editOrderDto.CreatedBy;
        order.CustomerName = editOrderDto.CustomerName;
        order.Status = editOrderDto.Status;
        order.AdditionalInformation = editOrderDto.AdditionalInformation;
        order.LastUpdated = DateTime.Now;
        _db.SaveChanges();

        return order;
    }

    public Order DeleteOrder(int id)
    {
        var order = _db.Orders.Include(x => x.Tl).Include(x => x.Cs).Include(x => x.Checklist).Single(x => x.Id == id);

        _db.Orders.Remove(order);
        _db.SaveChanges();

        return order;
    }
}
