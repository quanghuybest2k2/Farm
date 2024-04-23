import React, { useState } from "react";
import CIcon from "@coreui/icons-react";
import {
  CCard,
  CCardBody,
  CCardHeader,
  CCol,
  CRow,
  CTable,
  CTableBody,
  CTableDataCell,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
  CButton,
  CLink,
  CTooltip,
  CButtonGroup,
  CDropdown,
  CDropdownToggle,
  CDropdownMenu,
  CDropdownItem,
  CFormLabel,
  CModal,
  CModalBody,
  CModalHeader,
  CModalFooter,
  CModalTitle,
} from "@coreui/react";

import {
  cilTrash,
  cilColorBorder,
  cilCheckCircle,
  cilXCircle,
  cilPlus,
} from "@coreui/icons";

const AutoConfig = () => {
  const [selectedValue, setSelectedValue] = useState(null);
  const [visible, setVisible] = useState(false);

  const handleItemClick = (value) => {
    setSelectedValue(value);
  };

  return (
    <>
      <CRow>
        <CCol xs>
          <CCard className="mb-4">
            <CCardHeader>Automatic Configuration</CCardHeader>
            <CCardBody>
              <p className="text-body-secondary small">
                Basic information for the <code>Device</code>
                <CLink href={"#auto-config/create"}>
                  <CButton
                    color="success"
                    type="button"
                    size="sm"
                    className="float-end"
                  >
                    <CIcon icon={cilPlus} />
                    <text>Create New</text>
                  </CButton>
                </CLink>
              </p>
              <CTable responsive>
                <CTableHead>
                  <CTableRow>
                    <CTableHeaderCell scope="col">STT</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Type</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Area</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Area Sensor</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Device</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Status</CTableHeaderCell>
                    <CTableHeaderCell scope="col">From value</CTableHeaderCell>
                    <CTableHeaderCell scope="col">To value</CTableHeaderCell>
                    <CTableHeaderCell scope="col">From date</CTableHeaderCell>
                    <CTableHeaderCell scope="col">To date</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Is Active</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Action</CTableHeaderCell>
                  </CTableRow>
                </CTableHead>
                <CTableBody>
                  <CTableRow>
                    <CTableHeaderCell scope="row">1</CTableHeaderCell>
                    <CTableDataCell>Nhiệt độ</CTableDataCell>
                    <CTableDataCell>farm-2</CTableDataCell>
                    <CTableDataCell>KV2</CTableDataCell>
                    <CTableDataCell>Đèn 1</CTableDataCell>
                    <CTableDataCell>
                      <CIcon
                        icon={cilCheckCircle}
                        style={{ background: "green" }}
                      />
                    </CTableDataCell>
                    <CTableDataCell>25</CTableDataCell>
                    <CTableDataCell>30</CTableDataCell>
                    <CTableDataCell>08/04/2024</CTableDataCell>
                    <CTableDataCell>08/04/2024</CTableDataCell>
                    <CTableDataCell>
                      <CIcon
                        icon={cilCheckCircle}
                        style={{ background: "green" }}
                      />
                    </CTableDataCell>
                    <CTableDataCell>
                      <CButtonGroup
                        role="group"
                        aria-label="Basic mixed styles example"
                      >
                        <CCol xs={8}>
                          <CTooltip content="Edit">
                            <CLink href="#auto-config/edit/1">
                              <CButton color="warning" type="button" size="sm">
                                <CIcon icon={cilColorBorder} />
                              </CButton>
                            </CLink>
                          </CTooltip>
                        </CCol>
                        <CCol xs={8}>
                          <CTooltip content="Delete">
                            <CLink>
                              <CButton
                                color="danger"
                                type="button"
                                size="sm"
                                onClick={() => setVisible(!visible)}
                              >
                                <CIcon icon={cilTrash} />
                              </CButton>
                            </CLink>
                          </CTooltip>
                        </CCol>
                      </CButtonGroup>
                    </CTableDataCell>
                  </CTableRow>
                  <CTableRow>
                    <CTableHeaderCell scope="row">2</CTableHeaderCell>
                    <CTableDataCell>Ánh sáng</CTableDataCell>
                    <CTableDataCell>farm-2</CTableDataCell>
                    <CTableDataCell>KV2</CTableDataCell>
                    <CTableDataCell>Đèn 2</CTableDataCell>
                    <CTableDataCell>
                      <CIcon icon={cilXCircle} style={{ background: "red" }} />
                    </CTableDataCell>
                    <CTableDataCell>150</CTableDataCell>
                    <CTableDataCell>450</CTableDataCell>
                    <CTableDataCell>05/03/2024</CTableDataCell>
                    <CTableDataCell>10/04/2024</CTableDataCell>
                    <CTableDataCell>
                      <CIcon icon={cilXCircle} style={{ background: "red" }} />
                    </CTableDataCell>
                    <CTableDataCell>
                      <CButtonGroup
                        role="group"
                        aria-label="Basic mixed styles example"
                      >
                        <CCol xs={8}>
                          <CTooltip content="Edit">
                            <CLink>
                              <CButton color="warning" type="button" size="sm">
                                <CIcon icon={cilColorBorder} />
                              </CButton>
                            </CLink>
                          </CTooltip>
                        </CCol>
                        <CCol xs={8}>
                          <CTooltip content="Delete">
                            <CLink>
                              <CButton
                                color="danger"
                                type="button"
                                size="sm"
                                onClick={() => setVisible(!visible)}
                              >
                                <CIcon icon={cilTrash} />
                              </CButton>
                            </CLink>
                          </CTooltip>
                        </CCol>
                      </CButtonGroup>
                    </CTableDataCell>
                  </CTableRow>
                </CTableBody>
              </CTable>
              <br />
              <CFormLabel style={{ marginRight: "10px" }}>Show</CFormLabel>
              <CDropdown>
                <CDropdownToggle color="primary">
                  {selectedValue || "10"}
                </CDropdownToggle>
                <CDropdownMenu>
                  <CDropdownItem onClick={() => handleItemClick("10")}>
                    10
                  </CDropdownItem>
                  <CDropdownItem onClick={() => handleItemClick("20")}>
                    20
                  </CDropdownItem>
                  <CDropdownItem onClick={() => handleItemClick("30")}>
                    30
                  </CDropdownItem>
                </CDropdownMenu>
              </CDropdown>
              <CFormLabel style={{ marginLeft: "10px" }}>entices</CFormLabel>
            </CCardBody>
          </CCard>
        </CCol>
      </CRow>
      {/* model show */}
      <CModal
        backdrop="static"
        visible={visible}
        onClose={() => setVisible(false)}
        aria-labelledby="StaticBackdropExampleLabel"
      >
        <CModalHeader>
          <CModalTitle id="StaticBackdropExampleLabel">
            Are you sure you want to delete this item?
          </CModalTitle>
        </CModalHeader>
        <CModalBody>
          The data will be permanently deleted. Do you really want to continue?
        </CModalBody>
        <CModalFooter>
          <CButton color="primary">Submit</CButton>
          <CButton color="secondary" onClick={() => setVisible(false)}>
            Cancel
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  );
};

export default AutoConfig;
