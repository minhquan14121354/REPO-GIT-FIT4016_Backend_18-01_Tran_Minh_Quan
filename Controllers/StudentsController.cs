using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    // 1. API Lấy danh sách học sinh (GET: api/students)
    [HttpGet]
    public IActionResult GetStudents()
    {
        using (var context = new SchoolContext())
        {
            // Lấy danh sách kèm tên trường
            var list = context.Students.Include(s => s.School).ToList();
            return Ok(list);
        }
    }

    // 2. API Tìm học sinh theo ID (GET: api/students/SV00001)
    [HttpGet("{id}")]
    public IActionResult GetStudentById(string id)
    {
        using (var context = new SchoolContext())
        {
            var sv = context.Students.Include(s => s.School)
                            .FirstOrDefault(s => s.StudentId == id);
            if (sv == null) return NotFound("Khong tim thay sinh vien!");
            return Ok(sv);
        }
    }

    // 3. API Thêm học sinh mới (POST: api/students)
    [HttpPost]
    public IActionResult CreateStudent([FromBody] Student sv)
    {
        using (var context = new SchoolContext())
        {
            // Kiểm tra trùng ID
            if (context.Students.Any(s => s.StudentId == sv.StudentId))
                return BadRequest("Ma sinh vien da ton tai!");

            // Kiểm tra trường học có tồn tại không
            if (!context.Schools.Any(s => s.Id == sv.SchoolId))
                return BadRequest("ID Truong hoc khong ton tai!");

            // Gán ngày tạo
            sv.CreatedAt = System.DateTime.Now;
            sv.UpdatedAt = System.DateTime.Now;

            // Vì School là bảng quan hệ, ta gán null để tránh lỗi vòng lặp khi nhận JSON
            sv.School = null;

            context.Students.Add(sv);
            context.SaveChanges();
            return Ok(sv);
        }
    }

    // 4. API Xóa học sinh (DELETE: api/students/SV00001)
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(string id)
    {
        using (var context = new SchoolContext())
        {
            var sv = context.Students.FirstOrDefault(s => s.StudentId == id);
            if (sv == null) return NotFound("Khong tim thay de xoa!");

            context.Students.Remove(sv);
            context.SaveChanges();
            return Ok("Da xoa thanh cong!");
        }
    }
}