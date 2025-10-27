// Presentation/Controllers/SupplierController.cs
using Api.Models;
using Application.DTOs.Supplier;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SupplierController : Controller
{
    private readonly CreateSupplierUseCase _createSupplier;
    private readonly GetAllSupplierUseCase _getAllSuppliers;
    private readonly GetSupplierByIdUseCase _getSupplierById;
    private readonly UpdateSupplierUseCase _updateSupplier;
    private readonly DeleteSupplierUseCase _deleteSupplier;

    public SupplierController(
        CreateSupplierUseCase createSupplier,
        GetAllSupplierUseCase getAllSuppliers,
        GetSupplierByIdUseCase getSupplierById,
        UpdateSupplierUseCase updateSupplier,
        DeleteSupplierUseCase deleteSupplier
    )
    {
        _createSupplier = createSupplier;
        _getAllSuppliers = getAllSuppliers;
        _getSupplierById = getSupplierById;
        _updateSupplier = updateSupplier;
        _deleteSupplier = deleteSupplier;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] SupplierRequest request)
    {
        var response = await _createSupplier.ExecuteAsync(request);
        if (response == null)
            return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create supplier"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getAllSuppliers.ExecuteAsync();
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Suppliers not found"));
        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully")); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _getSupplierById.ExecuteAsync(id);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Supplier not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SupplierRequest request)
    {
        var response = await _updateSupplier.ExecuteAsync(id, request);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Supplier not found or update failed"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Update successfully"));
    }
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _deleteSupplier.ExecuteAsync(id);
        if (!success)
            return NotFound(ApiResponse<string>.ErrorResponse("Supplier not found or cannot delete"));
        return Ok(ApiResponse<string>.SuccessResponse("Delete successfully"));
    } }
