import { useEffect, useState } from "react";
import { Button, Table } from "react-bootstrap";
import { useNavigate } from "react-router";
import DeleteConfirmationModal from "../../shared/delete-confirmation";
import { requestUrl } from "../../utils/utilServices";

const AlbumPage = () => {
  const navigate = useNavigate();
  const [track, setTrack] = useState();
  const [showConfirmation, setShowConfirmation] = useState(false);

  useEffect(() => {
    artistList();
  }, []);
  const handleDelete = (id) => {
    fetch(`${requestUrl}Track/DeleteTrack?id=${id}`, {
      method: "DELETE",
    })
      .then(() => {
        var res = track.filter((x) => x.id !== id);
        setTrack(res);
        setShowConfirmation(false);
      })
      .catch((error) => {
        console.error("Error :", error);
      });
  };

  const artistList = () => {
    fetch(`${requestUrl}Track/GetTracks`, {
      method: "GET",
    })
      .then((res) => res?.json())
      .then((data) => {
        setTrack(data);
      })
      .catch((error) => {
        console.error("Error :", error);
      });
  };
  return (
    <div className="row">
      <div className="mb-2">
        <b style={{ fontSize: "20px" }}>Albums </b>
        <Button
          variant="primary"
          size="sm"
          className="float-end"
          onClick={() => navigate("add-track")}
        >
          Add
        </Button>
      </div>
      <div>
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>#</th>
              <th>Album</th>
              <th>Title</th>
              <th>Description</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {track?.length > 0 ? (
              track.map((item, index) => {
                return (
                  // eslint-disable-next-line react/jsx-key
                  <tr>
                    <td key={index}>{index + 1}</td>
                    <td>{item?.albumName}</td>
                    <td>{item?.title}</td>
                    <td>{item?.description.length > 100 ? item?.description.substring(0, 100) + "...." : item?.description}</td>
                    <td>
                      <Button
                        variant="info"
                        size="sm"
                        onClick={() => navigate(`edit-track/${item.id}`)}
                      >
                        Edit
                      </Button>{" "}
                      <Button
                        variant="danger"
                        size="sm"
                        onClick={() => setShowConfirmation(true)}
                      >
                        Delete
                      </Button>
                      <DeleteConfirmationModal
                        show={showConfirmation}
                        onHide={() => setShowConfirmation(false)}
                        onConfirm={() => handleDelete(item.id)}
                      />
                    </td>
                  </tr>
                );
              })
            ) : (
              <tr>
                <td colSpan={8} style={{ textAlign: "center" }}>
                  No Data Found.
                </td>
              </tr>
            )}
          </tbody>
        </Table>
      </div>
    </div>
  );
};
export default AlbumPage;
