/* test api
 * https://vapi-vnappmob.readthedocs.io/en/latest/province.html#quick-reference
 */

import axios from "axios";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Loading from "../../components/Loading";
import config from "../../config";
import swal from "sweetalert";

const Environment = () => {
  const [environments, setEnvironments] = useState([]);
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);

  useEffect(() => {
    axios.get(`${config.API_URL}/province`).then((res) => {
      //   console.log(res.data.results);
      if (res.data) {
        setEnvironments(res.data.results);
      } else {
        setEnvironments([]);
      }
      setIsVisibleLoading(false);
    });
  }, []);

  const deleteEnvironment = (e, id) => {
    e.preventDefault();
    const thisClicked = e.currentTarget;
    thisClicked.innerText = "Deleting...";
    axios
      .delete(`${config.API_URL}/environments/${id}/delete`)
      .then((res) => {
        if (res.data) {
          //   alert(res.data.message);
          swal("Success", res.data.message, "success");
          thisClicked.closest("tr").remove();
        }
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

  if (environments && environments.length > 0) {
    environmentDetail = environments.map((item, index) => (
      <tr key={index}>
        <td>{item.province_id}</td>
        <td>{item.province_name}</td>
        <td>{item.province_type}</td>
        <td>
          <Link
            to={`/environments/${item.province_id}/edit`}
            className="btn btn-success"
          >
            Edit
          </Link>
        </td>
        <td>
          <button
            type="button"
            onClick={(e) => deleteEnvironment(e, item.province_id)}
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
            Không tìm thấy thông tin môi trường!
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
                        <th>ID</th>
                        <th>Province Name</th>
                        <th>Province Type</th>
                        <th>Edit</th>
                        <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>{environmentDetail}</tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default Environment;
