import axios from "axios";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Loading from "../../components/Loading";
import config from "../../config";
import swal from "sweetalert";
import Pagination from "../../components/Pagination";

const Environment = () => {
  const [environments, setEnvironments] = useState([]);
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);
  // pagination
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [totalPage, setTotalPage] = useState(0);
  const [totalItems, setTotalItems] = useState(0);

  useEffect(() => {
    axios
      .get(
        `${config.API_URL}/environments?PageSize=${pageSize}&PageNumber=${pageNumber}`
      )
      .then((res) => {
        // pagination trong res.data
        console.log(res.data);
        if (res.data) {
          setPageNumber(res.data.pageNumber);
          setPageSize(res.data.pageSize);
          setTotalPage(res.data.totalPage);
          setTotalItems(res.data.totalItems);
          setEnvironments(res.data.results);
        } else {
          setEnvironments([]);
        }
        setIsVisibleLoading(false);
      });
  }, [pageSize, pageNumber]);

  const handlePageChange = (data) => {
    setPageNumber(data.selected + 1);
  };

  const deleteEnvironment = (e, id) => {
    e.preventDefault();
    const thisClicked = e.currentTarget;
    thisClicked.innerText = "Deleting...";
    axios
      .delete(`${config.API_URL}/environments/${id}`)
      .then((res) => {
        //   alert(res.data.message);
        swal("Success", "Deleted successfully", "success");
        thisClicked.closest("tr").remove();
      })
      .catch(function (error) {
        if (error.response) {
          if (error.response.status === 404) {
            swal("Oops!", error.response.data.message, "error");
            thisClicked.innerText = "Delete";
          }
          if (error.response.status === 500) {
            // alert(error.response.data);
            swal("Oops!", error.response.data, "error");
          }
        }
      });
  };

  var environmentDetail = "";
  let stt = 1;

  if (environments && environments.length > 0) {
    environmentDetail = environments.map((item, index) => (
      <tr key={index}>
        <td>{stt++}</td>
        <td>{item.temperature}</td>
        <td>{item.airQuality}</td>
        <td>{item.sensorLocation}</td>
        <td>{item.brightness}</td>
        <td>
          <Link
            to={`/environments/${item.id}/edit`}
            className="btn btn-success"
          >
            Edit
          </Link>
        </td>
        <td>
          <button
            type="button"
            onClick={(e) => deleteEnvironment(e, item.id)}
            className="btn btn-danger"
          >
            Delete
          </button>
        </td>
      </tr>
    ));
  } else {
    environmentDetail = (
      <tr>
        <td colSpan={5}>
          <h4 className="text-danger text-center">
            No environmental information found!
          </h4>
        </td>
      </tr>
    );
  }

  return (
    <>
      {isVisibleLoading ? (
        <Loading />
      ) : (
        <div className="container mt-5">
          <div className="row">
            <div className="col-md-12">
              <div className="card">
                <div className="card-header">
                  <h4>
                    Environments List
                    <Link
                      to="/environments/create"
                      className="btn btn-primary float-end"
                    >
                      Add Environment
                    </Link>
                  </h4>
                </div>
                <div className="card-body">
                  <table className="table table-striped">
                    <thead>
                      <tr>
                        <th>#</th>
                        <th>Temperature</th>
                        <th>Air Quality</th>
                        <th>Sensor Location</th>
                        <th>Brightness</th>
                        <th>Edit</th>
                        <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>{environmentDetail}</tbody>
                  </table>
                </div>
              </div>
            </div>
            <div className="mt-4 d-flex justify-content-between align-items-center">
              <span>
                Showing {pageSize} of {totalItems} items
              </span>
              {totalPage > 1 && (
                <Pagination
                  pageCount={totalPage}
                  onPageChange={handlePageChange}
                />
              )}
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default Environment;
