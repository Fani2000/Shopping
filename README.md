# Concepts from the course

### Docker container, images and Repository

* Firstly, you create your image by building and running an instance of your image locally
* Secondly you push your image to a docker repository where the images will be stored.

Kubenets commands


kubectl
	see organized commands

kubectl --help
kubectl version
kubectl cluster-info
kubectl get nodes 
kubectl get pod
kubectl get services
kubectl get all
kubectl get all -- pods, services, deployments..

-----------
Impritive - Declarative
Impritive Commands

kubectl run [container_name] --image=[image_name]
kubectl port-forward [pod] [ports]

kubectl create [resource]
kubectl apply [resource] -- create or modify resources

-----------
kubectl run swn-nginx --image=nginx
kubectl get pods
kubectl get all

kubectl port-forward swn-nginx 8080:80
kubectl delete deployment swn-nginx
kubectl get pods --watch
---------

kubectl create
	-- there is no pod 
	so its abraction from deployment so we should create deployment

kubectl create deployment name --image=image [--dry-run] [options]
kubectl create deployment nginx-depl --image=nginx
kubectl get deployment
kubectl get pod
kubectl get replicaset
kubectl get all
---------
Debugging Pods

kubectl logs nginx-depl-5c8bf76b5b-tzv2k

-- create new depl - mongo
kubectl create deployment mongo-depl --image=mongo
kubectl get pod
kubectl describe pod mongo-depl-5fd6b7d4b4-6xzjd
kubectl logs mongo-depl-5fd6b7d4b4-6xzjd
kubectl exec mongo-depl-5fd6b7d4b4-6xzjd -it sh
	ls
	mongo
		show dbs

-- delete reasource

kubectl get deployment
kubectl get replicaset

kubectl delete deployment nginx-depl
kubectl delete deployment mongo-depl

kubectl get pod --watch
kubectl get replicaset
---------