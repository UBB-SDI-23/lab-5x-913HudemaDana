import React, { useState } from "react";
import { PaginationOptions } from "../../models/helpers/PaginationOptions";
import { Button, Container, FormControl, FormLabel } from "react-bootstrap";
import { InputLabel, Select, MenuItem, Box, Card } from "@mui/material";

type PaginationProps = {
  totalCount: number;
  paginationOptions: PaginationOptions;
  onPageChange: (pageNumber: number) => void;
  onPageSizeChange: (pageSize: number) => void;
};

const CustomPagination = ({
  totalCount,
  paginationOptions,
  onPageChange,
  onPageSizeChange,
}: PaginationProps) => {
  const [page, setPage] = useState(paginationOptions.PageNumber);
  const [pageSize, setPageSize] = useState(paginationOptions.PageSize);
  const [sort, setSort] = useState("Id");

  const handlePageChange = (newPage: any) => {
    setPage(newPage);
    onPageChange(newPage);
  };

  const handlePageSizeChange = (event: any) => {
    const newPageSize = parseInt(event.target.value);
    setPageSize(newPageSize);
    onPageSizeChange(newPageSize);
  };

  const totalPages = Math.ceil(totalCount / pageSize);
  const currentPage = page;
  const maxPageNumbers = 6;

  let pageNumbers = [];

  if (totalPages <= maxPageNumbers) {
    pageNumbers = Array.from({ length: totalPages }, (_, i) => i + 1);
  } else {
    const firstPage = 1;
    const lastPage = totalPages;

    if (currentPage <= maxPageNumbers - 2) {
      pageNumbers = [...Array(maxPageNumbers - 1).keys()]
        .slice(1)
        .concat(lastPage);
    } else if (currentPage >= lastPage - maxPageNumbers + 3) {
      pageNumbers = [firstPage].concat(
        [...Array(maxPageNumbers - 1).keys()]
          .reverse()
          .slice(1)
          .map((i) => lastPage - i)
      );
    } else {
      const offset = Math.floor(maxPageNumbers / 2) - 1;
      pageNumbers = [
        firstPage,
        ...Array.from(
          { length: maxPageNumbers - 2 },
          (_, i) => currentPage - offset + i
        ),
        lastPage,
      ];
    }
  }

  return (
    <Box>
      <Container style={{ display: "flex", justifyContent: "space-between" }}>
        <ul
          className="pagination"
          style={{ marginTop: "1em", paddingLeft: "none" }}
        >
          {page >= 1 && (
            <li key="first" className="page-item">
              <Button
                className="page-link"
                onClick={() => handlePageChange(1)}
                style={{ borderRadius: "15%", border: "none" }}
              >
                {"<<"}
              </Button>
            </li>
          )}
          {currentPage >= 1 && (
            <li key="prev" className="page-item">
              <Button
                className="page-link"
                onClick={() => {
                  currentPage > 1 ? handlePageChange(currentPage - 1) : null;
                }}
                style={{ borderRadius: "15%", border: "none" }}
              >
                {"<"}
              </Button>
            </li>
          )}
          {pageNumbers.map((number) => (
            <li
              key={number}
              className={
                number === currentPage ? "page-item active" : "page-item"
              }
              style={{ marginLeft: "0.25em", marginRight: "0.25em" }}
            >
              <Button
                onClick={() => handlePageChange(number)}
                className="page-link"
                style={{ borderRadius: "15%", border: "none" }}
              >
                {number}
              </Button>
            </li>
          ))}
          {currentPage < totalPages - maxPageNumbers + 3 && (
            <li key="next" className="page-item">
              <Button
                className="page-link"
                onClick={() => {
                  currentPage < totalPages
                    ? handlePageChange(currentPage + 1)
                    : null;
                }}
                style={{ borderRadius: "15%", border: "none" }}
              >
                {">"}
              </Button>
            </li>
          )}
          {page < totalPages && (
            <li key="last" className="page-item">
              <Button
                className="page-link"
                onClick={() => handlePageChange(totalPages)}
                style={{ borderRadius: "15%", border: "none" }}
              >
                {">>"}
              </Button>
            </li>
          )}
        </ul>
        <Card
          className="page-size"
          sx={{
            flexDirection: "row",
            witdth: "15%",
            border: "none",
            boxShadow: "none",
            display: "flex",
            alignItems: "center",
            marginTop: "1em",
          }}
        >
          <InputLabel id="page-size-label" sx={{ marginRight: "1em" }}>
            Page Size:
          </InputLabel>
          <Select
            labelId="page-size-label"
            id="page-size"
            value={pageSize}
            onChange={handlePageSizeChange}
          >
            <MenuItem value={10} sx={{ padding: "10px 10px" }}>
              10
            </MenuItem>
            <MenuItem value={25} sx={{ padding: "10px 10px" }}>
              25
            </MenuItem>
            <MenuItem value={50} sx={{ padding: "10px 10px" }}>
              50
            </MenuItem>
          </Select>
        </Card>
      </Container>
    </Box>
  );
};

export default CustomPagination;
